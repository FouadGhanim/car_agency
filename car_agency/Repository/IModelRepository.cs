using car_agency.Models.Entities;

namespace car_agency.Repository
{
	public interface IModelRepository
	{
		void Delete(string id);
		List<Model> GetAll();
		Model GetById(string id);
		List<Model> GetBrandsById(int id);

    }
}
