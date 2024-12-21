using car_agency.Models.Data;
using car_agency.Models.Entities;

namespace car_agency.Repository
{
	public class CarBrandRepository : ICarBrandRepository
	{
        private readonly AppDbcontext context;

        public CarBrandRepository(AppDbcontext Context)
        {
            context = Context;
        }
        public void Delete(string id)
		{
			throw new NotImplementedException();
		}

		public List<CarBrand> GetAll()
		{
			return context.Brands.ToList();
		}

		public CarBrand GetById(string id)
		{
			throw new NotImplementedException();
		}
	}
}
