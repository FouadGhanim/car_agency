using car_agency.Models.Data;
using car_agency.Models.ViewModels;
using car_agency.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_agency.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly ICarRepository carRepo;
        private readonly IFeedbackRepository feedbackRepo;

        public AdminController(UserManager<ApplicationUser> userManager,IUserRepository userRepository,ICarRepository carRepo,IFeedbackRepository feedbackRepo )
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.carRepo = carRepo;
            this.feedbackRepo = feedbackRepo;
        }
        public async Task< IActionResult> AdminProfile()
        
        {
            var Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var Admin = await userManager.FindByIdAsync(Id);
            var AdminVM = new AdminViewModel();
            AdminVM.FullName= User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            AdminVM.Email= User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value.ToString();
            AdminVM.Image = Admin.Image;
            var Users = await userManager.GetUsersInRoleAsync("User");


            var UserViewModels = Users.Select(s => new ProfileViewModel
            {
                Id = s.Id,
                UserName = s.UserName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                UserImage=s.Image
                

            }).ToList();
            ViewBag.User = UserViewModels;

            return View(AdminVM);
        }
        public async Task< IActionResult> Delete(string Id)
        {
          var user=await userManager.FindByIdAsync(Id);
           await userManager.DeleteAsync(user);
            userRepository.Delete(Id);
            return RedirectToAction("AdminProfile");
        }
        [HttpGet]
        public async Task<IActionResult> UserCarRepo(string id)
        {
            var AdminId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var Admin = await userManager.FindByIdAsync(AdminId);
            var AdminVM = new AdminViewModel();
            AdminVM.FullName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            AdminVM.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value.ToString();
            AdminVM.Image = Admin.Image;

            var userCars = userRepository.GetUserWithCars(id);
            var firstCar = userCars.FirstOrDefault();
            var user = new ProfileViewModel
            {
                Id = firstCar.Id,
                PhoneNumber = firstCar.PhoneNumber,
                UserName = firstCar.UserName,
                Email = firstCar.Email,
                UserImage = firstCar.UserImage
            };


            ViewBag.Admin = AdminVM;
            ViewBag.UserCars = userCars;

            return View("Repo", user);
        }
         [HttpGet]
        public async Task< IActionResult> Confirm()
        {
            var Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var Admin = await userManager.FindByIdAsync(Id);
            var AdminVM = new AdminViewModel();
            AdminVM.FullName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            AdminVM.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value.ToString();
            AdminVM.Image = Admin.Image;
            var cars = carRepo.GetPendingCars();
            ViewBag.Admin = AdminVM;
            return View( cars);
        }

        public IActionResult Confirmation(int id)
        {
            carRepo.ApproveCar(id);
            return RedirectToAction("Confirm");
        }
        public IActionResult Cancel(int id)
        {
            carRepo.Delete(id);
            return RedirectToAction("Confirm");
        }
        [HttpGet]
        public async Task<IActionResult> CarReport()
        {
            var Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var Admin = await userManager.FindByIdAsync(Id);
            var AdminVM = new AdminViewModel();
            AdminVM.FullName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            AdminVM.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value.ToString();
            AdminVM.Image = Admin.Image;
            var cars = carRepo.GetCarsDetails();
            ViewBag.Admin = AdminVM;
            return View(cars);
        }
        public IActionResult DeleteCar(int id)
        {
            carRepo.Delete(id);
            return RedirectToAction("CarReport");
        }
        public async Task< IActionResult> ShowFeedback()
        {
            var Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var Admin = await userManager.FindByIdAsync(Id);
            var AdminVM = new AdminViewModel();
            AdminVM.FullName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value.ToString();
            AdminVM.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value.ToString();
            AdminVM.Image = Admin.Image;
            var AllFeedback = feedbackRepo.GetAllFeedBacks();
            ViewBag.Admin = AdminVM;
            return View(AllFeedback);
        }
        public IActionResult DeleteFeedback(int id)
        {
            feedbackRepo.Delete(id);
            return RedirectToAction("ShowFeedback");
        }
    }
}
