using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public class PaymentRepository : IPaymentRepository
	{
        private readonly AppDbcontext dbcontext;

        public PaymentRepository(AppDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Delete(string id)
		{
			throw new NotImplementedException();
		}

		public List<Payment> GetAll()
		{
			throw new NotImplementedException();
		}

		public Payment GetById(string id)
		{
			throw new NotImplementedException();
		}

		public bool IsPaid(string id)
		{
			var pay = dbcontext.Payments.FirstOrDefault(x => x.UserId == id);
			if (pay != null)
			{
				return true;
			}
			else return false;
		}

		public void Update(string id, Payment user)
		{
			throw new NotImplementedException();
		}
        public void Insert(PaymentViewModel payment, string Id)
        {
            Payment newpay = new Payment();
			newpay.Id = payment.Id;
            newpay.CardNumber = payment.CardNumber;
			newpay.AdvertisementType = payment.AdvertisementType;
            newpay.CVV = payment.CVV;
            newpay.UserId = Id;
            dbcontext.Payments.Add(newpay);
            dbcontext.SaveChanges();
        }
    }
}
