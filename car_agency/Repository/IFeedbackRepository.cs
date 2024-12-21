using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public interface IFeedbackRepository
	{
		void Update(int id, Feedback feedBack);
		void Delete(int id);
		List<Feedback> GetAllFeedBacks();
		Feedback GetById(int id);
		public void Insert(FeedBackViewModel feedBack);
	}
}
