using car_agency.Models.Data;
using car_agency.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace car_agency
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbcontext>(options => {
				options.UseSqlServer(builder.Configuration.GetSection("cs").Value);
				});
			builder.Services.AddScoped<ICarRepository, CarRepository>();
			builder.Services.AddScoped<ICarBrandRepository, CarBrandRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
			builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
			builder.Services.AddScoped<IModelRepository, ModelRepository>();
			builder.Services.AddScoped<IFileService, FileService>();
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbcontext>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Landing}/{action=Welcome}/{id?}");

			app.Run();
		}
	}
}
