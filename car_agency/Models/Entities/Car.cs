namespace car_agency.Models.Entities
{
	public class Car
	{
		public int CarId { get; set; }
		public bool Status { get; set; }
		public string Image { get; set; }
		public string Year { get; set; }
		public int ModelId { get; set; }
		public string CarStatus { get; set; }
        public string? Descraption { get; set; }
        public string FuelType { get; set; }
        public int BrandId { get; set; }
		public string PhoneNumber { get; set; }
		public string Engine { get; set; }
		public bool IsApproved { get; set; }
		public decimal Price { get; set; }
		public string Transmission { get; set; }
        public string Mileage { get; set; }


        public string UserId { get; set; }

        public Model Model  { get; set; }
        public CarBrand CarBrand { get; set; }
        public User User { get; set; }
	}

}
