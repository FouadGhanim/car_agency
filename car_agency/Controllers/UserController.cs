using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;
using car_agency.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_agency.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly ICarRepository carRepository;
        private readonly AppDbcontext dbcontext;
		private readonly IFileService fileService;

		public UserController(UserManager<ApplicationUser>userManager , IUserRepository userRepository,ICarRepository carRepository , AppDbcontext dbcontext , IFileService fileService)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.carRepository = carRepository;
            this.dbcontext = dbcontext;
			this.fileService = fileService;
		}
        public async Task< IActionResult> Profile()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var userCars = userRepository.GetUserWithCars(id);
            var user = new ProfileViewModel
            {
                Id = userCars.First().Id,
                PhoneNumber = userCars.First().PhoneNumber,
                UserName = userCars.First().UserName,
                Email = userCars.First().Email,
                UserImage = userCars.First().UserImage,
                
            };

            
            ViewBag.UserCars = userCars;

            return View(user);

            
        }
        public IActionResult Sold(int Id)
        {
            var oldCar = carRepository.GetById(Id);
            oldCar.Status = true;
            dbcontext.SaveChanges();
            return RedirectToAction("Profile");
        }
        public IActionResult Delet(int Id)
        {
             carRepository.Delete(Id);

            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel NewUser)
        {
            if (ModelState.IsValid)
            {
				if (NewUser.ImageFile != null)
				{

					NewUser.Image = await fileService.SaveFileAsync(NewUser.ImageFile, "UserImages");
				}
				string Id= User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();

                 
                var user = await userManager.FindByIdAsync(Id);
                user.Email = NewUser.Email;
                user.PhoneNumber = NewUser.PhoneNumber;
                user.UserName = NewUser.Fname;
                user.LastName = NewUser.Lname;
                user.Image = NewUser.Image;
                user.NormalizedEmail = NewUser.Email.ToUpper();
                var existingUser = await userManager.FindByEmailAsync(NewUser.Email);
                if (existingUser != null && existingUser.Id != Id)
                {
                    ModelState.AddModelError("Email", "This email is already in use.");
                    return View(NewUser);
                }
                userRepository.Update(Id, NewUser);
                await userManager.UpdateAsync(user);
                return RedirectToAction("Profile");
            }
            else
            {
                ModelState.AddModelError("", "Wrong Email or Email or Phone Number or name");
            }
            return View(NewUser);
        }
    }
}
