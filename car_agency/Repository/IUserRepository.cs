using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public interface IUserRepository
	{
		void Insert(RegisteViewModel user, string id);
		void Update(string id, EditUserViewModel user);
		void Delete(string id);
		List<User> GetAll();
		User GetById(string id);
        List<ProfileViewModel> GetUserWithCars(string id);	
	}
}
