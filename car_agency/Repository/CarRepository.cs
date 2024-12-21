using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace car_agency.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbcontext context;

        public CarRepository(AppDbcontext context)
        {
            this.context = context;
        }
        public void Delete(int Id)
        {
            var Car= GetById(Id);
            context.Cars.Remove(Car);
            context.SaveChanges();
        }

        public List<Car> Getall()
        {
          return context.Cars.ToList();
        }

        public Car GetById(int id)
        {
           return context.Cars.Include(car => car.CarBrand) 
        .Include(car => car.Model)
        .FirstOrDefault(x => x.CarId == id);
        }

        public void Insert(CarViewModel Addcar,string Id)
        {
            Car NewCar = new Car();
            NewCar.UserId = Id;
            NewCar.Year = Addcar.Year;
            NewCar.Status = Addcar.Status=false;
            NewCar.Price = Addcar.Price;
            NewCar.CarStatus = Addcar.CarStatus;
            NewCar.Image = Addcar.Image;
            NewCar.ModelId = Addcar.ModelId;
            NewCar.IsApproved = Addcar.IsApproved = false;
            NewCar.BrandId = Addcar.BrandId;
            NewCar.Descraption = Addcar.Descraption;
            NewCar.FuelType = Addcar.FuelType;
            NewCar.PhoneNumber = Addcar.PhoneNumber;
            NewCar.Engine = Addcar.Engine;
            NewCar.Transmission = Addcar.Transmission;
            NewCar.Mileage = Addcar.Mileage;
            context.Add(NewCar);
            context.SaveChanges();
        }
       
        
            public IEnumerable<CarConfirmViewModel> GetPendingCars()
            {
                var result = (from car in context.Cars
                              join user in context.Users
                              on car.UserId equals user.UserId 
                              where !car.IsApproved
                              select new CarConfirmViewModel
                              {
                                  Id = car.CarId,
                                  CarName = $"{car.CarBrand.BrandName} {car.Model.ModelName}",
                                  Engine = car.Engine,
                                  Mileage = car.Mileage,
                                  Year = car.Year,
                                  Price = car.Price,
                                  IsApproved = car.IsApproved,
                                  CarImage=car.Image,
                                  Transmission=car.Transmission,
                                  UserName = $"{user.FName} {user.LName}",
                                  Email = user.Email
                              }).ToList();

                return result;
            }
        

        public void ApproveCar(int carId)
        {
            var car = context.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                car.IsApproved = true;
                context.SaveChanges();
            }
        }
        public IEnumerable<CarDetailsViewModel> GetCarsDetails()
        {
            var result = (from car in context.Cars
                          join user in context.Users
                          on car.UserId equals user.UserId
                          select new CarDetailsViewModel
                          {
                          CarImage=car.Image,
                          CarName= $"{car.CarBrand.BrandName} {car.Model.ModelName}",
                          CarSatues=car.CarStatus,
                          Satues=car.Status,
                          Id=car.CarId,
                          Price=car.Price,
                          UserName= $"{user.FName} {user.LName}",
                          Email=user.Email

                          }
                              ).ToList();
            return result;
        }
        public List<ProductViewModel> getcars()
        {
            var car = context.Cars.Where(s=>s.IsApproved==true)
                .Select(s => new ProductViewModel
                {
                Id=s.CarId,
                Image = s.Image,
                price = s.Price,
                CarStatues = s.CarStatus,
                FullName = $"{s.CarBrand.BrandName} {s.Model.ModelName}",
                IsApproved=s.IsApproved,
                Statues=s.Status
            }).ToList();
            return car;
        }
        public List<ProductViewModel> GetCarsByBrandId(int brandId)
        {
            var cars = context.Cars
                .Where(s => s.CarBrand.BrandId == brandId & s.IsApproved== true) 
                .Select(s => new ProductViewModel
                {
                    Id = s.CarId,
                    Image = s.Image,
                    price = s.Price,
                    CarStatues = s.CarStatus,
                    FullName = $"{s.CarBrand.BrandName} {s.Model.ModelName}",
                    IsApproved = s.IsApproved
                })
                .ToList();

            return cars;
        }
        public List<ProductViewModel> GetUsedCars()
        {
            var cars = context.Cars
                .Where(s => s.CarStatus=="Used" & s.IsApproved== true)
                .Select(s => new ProductViewModel
                {
                    Id = s.CarId,
                    Image = s.Image,
                    price = s.Price,
                    CarStatues = s.CarStatus,
                    FullName = $"{s.CarBrand.BrandName} {s.Model.ModelName}",
                    IsApproved = s.IsApproved
                })
                .ToList();

            return cars;
        }
        public List<ProductViewModel> GetNewCars()
        {
            var cars = context.Cars
                .Where(s => s.CarStatus == "New" && s.IsApproved==true)
                .Select(s => new ProductViewModel
                {
                    Id = s.CarId,
                    Image = s.Image,
                    price = s.Price,
                    CarStatues = s.CarStatus,
                    FullName = $"{s.CarBrand.BrandName} {s.Model.ModelName}",
                    IsApproved = s.IsApproved
                })
                .ToList();

            return cars;
        }
    }
}
