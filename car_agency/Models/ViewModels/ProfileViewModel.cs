using System.ComponentModel.DataAnnotations;

namespace car_agency.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public bool? Status { get; set; }
        public string CarName { get; set; }
        public string mile { get; set; }
        public string carImage { get; set; }
        public string UserImage { get; set; }
        public string year { get; set; }
        public bool IsApproved { get; set; }
        public string Engin { get; set; }
    }
}
