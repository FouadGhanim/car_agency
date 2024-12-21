namespace car_agency.Models.ViewModels
{
    public class CarConfirmViewModel
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Engine { get; set; }
        public string Mileage { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public bool IsApproved { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CarImage { get; set; }
        public string Transmission { get; set; }
        
    }
}
