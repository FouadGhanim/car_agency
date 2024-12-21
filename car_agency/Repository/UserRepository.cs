using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace car_agency.Repository
{
	public class UserRepository : IUserRepository
	{
		public AppDbcontext Context;
		public UserRepository(AppDbcontext Context)
        {
			this.Context = Context;
		}

		

		public void Delete(string id)
		{
			var student = GetById(id);


			Context.Users.Remove(student);
			Context.SaveChanges();
		}

		public List<User> GetAll()
		{
			return Context.Users.ToList();
		}

		public User GetById(string id)
		{
            return Context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<ProfileViewModel> GetUserWithCars(string userId)
        {
            var result = (from user in Context.Users.Where(u => u.UserId == userId)
                          join car in Context.Cars on user.UserId equals car.UserId into userCars
                          from car in userCars.DefaultIfEmpty() // Left join
                          select new ProfileViewModel
                          {
                              Id = user.UserId,
                              Email = user.Email,
                              PhoneNumber = user.Phone,
                              UserImage = user.Image ?? "~/images/default-user.jpg",
                              UserName = $"{user.FName} {user.LName}",
                              CarId = car == null ? 0 : car.CarId,
                              Price = car == null ? 0.0m : car.Price,
                              Status = car != null && car.Status, // Handle null check manually
                              CarName = car == null ? "No Car" : $"{car.CarBrand.BrandName} {car.Model.ModelName}",
                              mile = car == null ? "0" : car.Mileage,
                              carImage = car == null ? "~/images/default-user.jpg" : car.Image,
                              year = car == null ? "0" : car.Year,
                              IsApproved = car != null && car.IsApproved,
                              Engin = car == null ? "Unknown Engine" : car.Engine
                          }).ToList();
			return result;
        }


        public void Insert(RegisteViewModel user, string id)
		{
			User NewUser = new User();
			NewUser.UserId = id;
			NewUser.Phone = user.PhoneNumber;
			NewUser.Image = user.ImagePath;
			NewUser.FName = user.FName;
			NewUser.LName = user.LName;
			NewUser.Email = user.Email;
			Context.Users.Add(NewUser);
			Context.SaveChanges();
		}

		public void Update( string Id,EditUserViewModel user )
		{
			User NewUser = GetById(Id);
			NewUser.FName = user.Fname;
			NewUser.LName = user.Lname;
			NewUser.Phone = user.PhoneNumber;
			NewUser.Image = user.Image;
			NewUser.Email = user.Email;
			Context.SaveChanges();

			
		}
	}
}
