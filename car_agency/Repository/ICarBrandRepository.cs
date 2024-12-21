using car_agency.Models.Entities;

namespace car_agency.Repository
{
	public interface ICarBrandRepository
	{
		
		void Delete(string id);
		List<CarBrand> GetAll();
		CarBrand GetById(string id);
	}
}
