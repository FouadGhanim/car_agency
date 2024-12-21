using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;
using car_agency.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_agency.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IUserRepository userRepository;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IFileService fileService;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager, IUserRepository userRepository, RoleManager<IdentityRole> roleManager,IFileService fileService)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.userRepository = userRepository;
			this.roleManager = roleManager;
			this.fileService = fileService;
		}
        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task< IActionResult> SaveRegister(RegisteViewModel userVM)
		{
			if (ModelState.IsValid)
			{
				if (userVM.ImageFile != null)
				{
					
					userVM.ImagePath = await fileService.SaveFileAsync(userVM.ImageFile, "UserImages");
				}
				ApplicationUser user = new ApplicationUser();
				user.Email = userVM.Email;
				user.UserName = userVM.FName;
				user.LastName = userVM.LName;
				user.PhoneNumber = userVM.PhoneNumber;
				user.Image = userVM.ImagePath;
				user.PasswordHash = userVM.Password;
				var result = await userManager.CreateAsync(user, userVM.Password);
				if (result.Succeeded)
				{
					if (!await roleManager.RoleExistsAsync("User"))
					{
						await roleManager.CreateAsync(new IdentityRole("User"));
					}
					await userManager.AddToRoleAsync(user, "User");
					userRepository.Insert(userVM, user.Id);
					signInManager.SignInAsync(user, false);
					return RedirectToAction("Login", "Account");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
		         }
			}
			return View("Register",userVM);
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel userVM)
		{
			if (ModelState.IsValid)
			{
				var applicationUser = await userManager.FindByEmailAsync(userVM.Email);
				if (applicationUser != null)
				{
					bool isPasswordValid = await userManager.CheckPasswordAsync(applicationUser, userVM.Password);
					if (isPasswordValid)
					{
						var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, applicationUser.UserName + " " + applicationUser.LastName),
					new Claim(ClaimTypes.Email, applicationUser.Email),
					new Claim("Image", applicationUser.Image),
					new Claim(ClaimTypes.MobilePhone, applicationUser.PhoneNumber)
				};

						await signInManager.SignInWithClaimsAsync(applicationUser, false, claims);
						return RedirectToAction("Welcome", "Landing");
					}
					else
					{
						ModelState.AddModelError("Password", "Invalid password.");
					}
				}
				else
				{
					ModelState.AddModelError("Email", "Email not found.");
					
				}
				
				
					
				
			}

			
			return View(userVM);
		}

		[Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Welcome", "Landing");
        }


    }
}
