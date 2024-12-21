namespace car_agency.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public decimal price { get; set; }
        public string CarStatues { get; set; }
        public string FullName { get; set; }
        public bool IsApproved { get; set; }
        public bool Statues { get; set; }
    }
}
