using System.ComponentModel.DataAnnotations;

namespace car_agency.Models.ViewModels
{
    public class CarViewModel
    {
       
        public bool Status { get; set; }
        [Range(2000, 2025, ErrorMessage = "Year must be 2025 or earlier.")]
        public string Year { get; set; }
        public int ModelId { get; set; }
        [RegularExpression(@"^(New|Used)$", ErrorMessage = "Car status must be either 'New' or 'Used'.")]
        public string CarStatus { get; set; }
        public string? Descraption { get; set; }
        public string FuelType { get; set; }
        public int BrandId { get; set; }
        [StringLength(11, ErrorMessage = "Phone Number is invalid")]
        public string PhoneNumber { get; set; }
       // [RegularExpression(@"^\d{5}[A-Za-z]{3}$", ErrorMessage = "Engine must contain exactly 5 digits followed by 3 letters.")]
        public string Engine { get; set; }
        public bool IsApproved { get; set; }
        public decimal Price { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? Image { get; set; }
        
    }
}
