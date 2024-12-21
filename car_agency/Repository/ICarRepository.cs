using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public interface ICarRepository
	{
		List<Car> Getall();
		void Delete(int Id);
		Car GetById(int id);
		void Insert(CarViewModel car,string Id);
		public IEnumerable<CarConfirmViewModel> GetPendingCars();
		public void ApproveCar(int carId);
        public IEnumerable<CarDetailsViewModel> GetCarsDetails();
		public List<ProductViewModel> getcars();
		public List<ProductViewModel> GetCarsByBrandId(int brandId);
		public List<ProductViewModel> GetUsedCars();
		public List<ProductViewModel> GetNewCars();

    }
}
