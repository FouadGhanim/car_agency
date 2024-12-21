using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;
using car_agency.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace car_agency.Controllers
{
    public class LandingController : Controller
    {
        private readonly ICarRepository carRepository;
        private readonly ICarBrandRepository carBrand;
        private readonly IModelRepository model;
        private readonly IPaymentRepository payment;
        private readonly IFeedbackRepository feedbackRepo;
		private readonly IFileService fileService;

		public LandingController(ICarRepository carRepository, ICarBrandRepository carBrand, IModelRepository model, UserManager<ApplicationUser> user, IPaymentRepository payment, IFeedbackRepository feedbackRepo, IFileService fileService)
        {
            this.carRepository = carRepository;
            this.carBrand = carBrand;
            this.model = model;
            this.payment = payment;
            this.feedbackRepo = feedbackRepo;
			this.fileService = fileService;
		}
        public IActionResult Welcome()
        {

            if (User.Identity.IsAuthenticated == true)
            {
                if (User.IsInRole("Admin"))
                {
                    var UserName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
                    ViewBag.Name = UserName;
                    return RedirectToAction("AdminProfile", "Admin");
                }
                else
                {
                    var UserName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
                    ViewBag.Name = UserName;
                }
            }
            else
            {
                var UserName = "User";
                ViewBag.Name = UserName;

            }
            var car = carRepository.getcars();
            return View(car);
        }
        public IActionResult SellCar()
        {
            ViewBag.BrandName = carBrand.GetAll();
            ViewBag.ModelName = model.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellCar(CarViewModel Addcar)
        {
            ViewBag.pay = false;
            if (ModelState.IsValid)
            {
				if (Addcar.ImageFile != null)
				{

					Addcar.Image = await fileService.SaveFileAsync(Addcar.ImageFile, "CarsImages");
				}
				string Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
                if (payment.IsPaid(Id))
                {
                    ViewBag.pay = true;
                    carRepository.Insert(Addcar, Id);

                    return RedirectToAction("Welcome");
                }
                else
                {
                    ViewBag.BrandName = carBrand.GetAll();
                    ViewBag.ModelName = model.GetAll();

                    return RedirectToAction("Pay");
                }
            }

            return View(Addcar);
        }
        public IActionResult GetModelsPerBrand(int BrandId)
        {
            var Models = model.GetBrandsById(BrandId);
            return Json(Models);
        }

        public IActionResult Pay()
        {

            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(PaymentViewModel Payment)
        {

            if (ModelState.IsValid)
            {
                var Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
                payment.Insert(Payment, Id);
                return RedirectToAction("SellCar");
            }

            return View("Pay", Payment);
        }
        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(FeedBackViewModel model)
        {

            model.UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            if (ModelState.IsValid)
            {
                feedbackRepo.Insert(model);
                return RedirectToAction("Welcome", "Landing");
            }
            return View(model);
        }
        public IActionResult Products()
        {
            var car = carRepository.getcars();
            return View(car);
        }
        public IActionResult ProductsByBrand(int Id)
        {
            var car = carRepository.GetCarsByBrandId(Id);
            return View("Products", car);
        }
        public IActionResult UsedProducts()
        {
            var car = carRepository.GetUsedCars();
            return View("Products", car);
        }
        public IActionResult NewProducts()
        {
            var car = carRepository.GetNewCars();
            return View("Products", car);
        }
        public IActionResult Details(int Id)
        {
            var car = carRepository.GetById(Id);
            var CarDetails = new Details();
            CarDetails.Status = car.Status;
            CarDetails.CarStatus = car.CarStatus;
            CarDetails.FullName = $"{car.CarBrand.BrandName} {car.Model.ModelName}";
            CarDetails.PhoneNumber = car.PhoneNumber;
            CarDetails.Transmission = car.Transmission;
            CarDetails.Descraption = car.Descraption;
            CarDetails.FuelType = car.FuelType;
            CarDetails.Engine = car.Engine;
            CarDetails.Year = car.Year;
            CarDetails.Mileage = car.Mileage;
            CarDetails.Image = car.Image;
            CarDetails.Price = car.Price;
            CarDetails.BrandName = car.CarBrand.BrandName;
            CarDetails.ModelName = car.Model.ModelName;

            return View(CarDetails);
        }
        
        [HttpGet]
        public IActionResult Prediction()
        {
            // Pass brand and model data to the view
            ViewBag.BrandNames = CarMappings.BrandMapping.Keys.ToList();
            ViewBag.PredictedPrice = 0;
            return View(new PredictionViewModel());
        }

        [HttpPost]
        public IActionResult Prediction(PredictionViewModel model)
        {
            // Encode BrandName, ModelName, Transmission, and FuelType
            int encodedBrand = EncodeBrandName(model.BrandName);
            int encodedModel = EncodeModelName(model.BrandName, model.ModelName);
            int encodedTransmission = EncodeTransmission(model.Transmission);
            int encodedFuel = EncodeFuel(model.FuelType);

            // Check for invalid mappings
            if (encodedBrand == -1 || encodedModel == -1 || encodedTransmission == -1 || encodedFuel == -1)
            {
                ModelState.AddModelError(string.Empty, "Invalid input values. Please check your selections.");
                return View(model);
            }

            // Prepare input for ONNX
            var inputs = PrepareOnnxInputs(model, encodedBrand, encodedModel, encodedTransmission, encodedFuel);

            // Call ONNX model
            double predictedPrice;
            try
            {
                predictedPrice = PredictPriceWithOnnx(inputs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error during prediction: {ex.Message}");
                return View(model);
            }

            // Pass result back to the view
            ViewBag.PredictedPrice = predictedPrice;
            ViewBag.BrandNames = CarMappings.BrandMapping.Keys.ToList();
            return View(model);
        }

        private int EncodeBrandName(string brandName)
        {
            return CarMappings.BrandMapping.TryGetValue(brandName, out var value) ? value : -1;
        }

        private int EncodeTransmission(string transmission)
        {
            return CarMappings.TransMapping.TryGetValue(transmission, out var value) ? value : -1;
        }

        private int EncodeFuel(string fuel)
        {
            return CarMappings.FuelMapping.TryGetValue(fuel, out var value) ? value : -1;
        }

        private int EncodeModelName(string brandName, string modelName)
        {
            if (CarMappings.ModelMapping.ContainsKey(brandName) &&
                CarMappings.ModelMapping[brandName].TryGetValue(modelName, out var value))
            {
                return value;
            }
            return -1;
        }

        private List<NamedOnnxValue> PrepareOnnxInputs(PredictionViewModel model, int encodedBrand, int encodedModel, int encodedTransmission, int encodedFuel)
        {
            return new List<NamedOnnxValue>
    {
        NamedOnnxValue.CreateFromTensor("Brand", new DenseTensor<string>(new[] { CarMappings.BrandMapping.FirstOrDefault(b => b.Value == encodedBrand).Key }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("model", new DenseTensor<string>(new[] { CarMappings.ModelMapping[model.BrandName].FirstOrDefault(m => m.Value == encodedModel).Key }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("transmission", new DenseTensor<string>(new[] { CarMappings.TransMapping.FirstOrDefault(t => t.Value == encodedTransmission).Key }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("fuelType", new DenseTensor<string>(new[] { CarMappings.FuelMapping.FirstOrDefault(f => f.Value == encodedFuel).Key }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("mileage", new DenseTensor<float>(new[] { model.Mileage }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("engineSize", new DenseTensor<float>(new[] { model.Engine }, new[] { 1,1 })),
        NamedOnnxValue.CreateFromTensor("year", new DenseTensor<float>(new[] { model.Year }, new[] { 1,1 }))
    };
        }

        private double PredictPriceWithOnnx(List<NamedOnnxValue> inputs)
        {
            // Replace with actual model path
            using var session = new InferenceSession(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Model", "car_price_pipeline.onnx"));
            using var results = session.Run(inputs);
            return results.First().AsTensor<float>().First();
        }

    }
}

