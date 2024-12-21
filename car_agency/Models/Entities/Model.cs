namespace car_agency.Models.Entities
{
	public class Model
	{
		public int ModelId { get; set; }
		public string ModelName { get; set; }
		public int BrandId { get; set; }
		public CarBrand CarBrand { get; set; }
		public ICollection<Car> Cars { get; set; }
	}
}
