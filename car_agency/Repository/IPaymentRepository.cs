using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public interface IPaymentRepository
	{
		bool IsPaid(string id);
		void Update(string id, Payment user);
		void Delete(string id);
		List<Payment> GetAll();
		Payment GetById(string id);
		void Insert(PaymentViewModel payment, string Id);

    }
}
