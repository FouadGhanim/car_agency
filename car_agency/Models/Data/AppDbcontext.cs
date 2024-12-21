using car_agency.Models.Data.config;
using car_agency.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace car_agency.Models.Data
{
	public class AppDbcontext:IdentityDbContext<ApplicationUser>
	{

		public DbSet<Car> Cars { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<CarBrand> Brands { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Feedback>Feedbacks { get; set; }
        public AppDbcontext(DbContextOptions options) : base(options)
        {
            
        }
        public AppDbcontext():base()
        {
            
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
		}


	}
}
