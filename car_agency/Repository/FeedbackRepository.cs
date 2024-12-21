using car_agency.Models.Data;
using car_agency.Models.Entities;
using car_agency.Models.ViewModels;

namespace car_agency.Repository
{
	public class FeedbackRepository : IFeedbackRepository
	{
        private readonly AppDbcontext dbcontext;

        public FeedbackRepository(AppDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Delete(int id)
		{
			var feedback= GetById(id);

			dbcontext.Remove(feedback);
			dbcontext.SaveChanges();

        }

		public List<Feedback> GetAllFeedBacks()
		{
			return dbcontext.Feedbacks.ToList();
		}

		public Feedback GetById(int id)
		{
            return dbcontext.Feedbacks.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(FeedBackViewModel model)
        {
			var NewFeedBack = new Feedback();
			NewFeedBack.feedBack = model.FeedBack;
			NewFeedBack.Subject = model.Subject;
			NewFeedBack.Email = model.Email;
			NewFeedBack.UserId = model.UserId;
			NewFeedBack.FullName = model.FullName;
			dbcontext.Feedbacks.Add(NewFeedBack);
			dbcontext.SaveChanges();
        }

        public void Update(int id, Feedback feedBack)
		{
			throw new NotImplementedException();
		}

	}
}
