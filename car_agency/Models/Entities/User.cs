namespace car_agency.Models.Entities
{
	public class User
	{
		public string UserId { get; set; }
		public string FName { get; set; }
		public string LName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Image { get; set; }
		



        public List<Car>? Cars { get; set; } = new List<Car>();
		public List<Payment> Payments { get; set; } = new List<Payment>();
		public List<Feedback>? Feedbacks { get; set; } = new List<Feedback>();
	}

}
