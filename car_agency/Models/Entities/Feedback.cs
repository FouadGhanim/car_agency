namespace car_agency.Models.Entities
{
	public class Feedback
	{
		
		
		public int Id { get; set; }
		public string feedBack { get; set; }
        public string Subject { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
		public string UserId { get; set; }
		
	}
}
