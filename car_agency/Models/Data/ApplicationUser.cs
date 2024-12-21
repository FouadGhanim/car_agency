using Microsoft.AspNetCore.Identity;

namespace car_agency.Models.Data
{
	public class ApplicationUser :IdentityUser
	{
        public string Image { get; set; }
		public string LastName { get; set; }
	}
}
