using System.ComponentModel.DataAnnotations;

namespace car_agency.Models.ViewModels
{
    public class EditUserViewModel
    {
        [StringLength(15)]
        public string Fname { get; set; }
        [StringLength(15)]
        public string Lname { get; set; }
        [StringLength(11, ErrorMessage = "Phone Number is invalid")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? Image { get; set; }
    }
}
