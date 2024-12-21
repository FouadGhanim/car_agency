using System.ComponentModel.DataAnnotations;

namespace car_agency.Models.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
		[StringLength(11, ErrorMessage = "Phone Number is invalid")]
        public string PhoneNumber { get; set; }
    }
}
