using car_agency.Models.Data;
using car_agency.Models.Entities;

namespace car_agency.Repository
{
	public class ModelRepository : IModelRepository
	{
        private readonly AppDbcontext context;

        public ModelRepository(AppDbcontext Context)
		{
            context = Context;
        }
		public void Delete(string id)
		{
			throw new NotImplementedException();
		}

		public List<Model> GetAll()
		{
			return context.Models.ToList();
		}

		public Model GetById(string id)
		{
			throw new NotImplementedException();
		}
        public List< Model> GetBrandsById(int id)
        {
			return context.Models.Where(x => x.BrandId == id).ToList();
        }
    }
}
