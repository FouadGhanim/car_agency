namespace car_agency.Models.Entities
{
	public class CarBrand
	{
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars = new List<Car> ();
		public List<Model> Models = new List<Model>();

	}
}
