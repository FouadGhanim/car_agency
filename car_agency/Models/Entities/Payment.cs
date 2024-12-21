namespace car_agency.Models.Entities
{
	public class Payment
	{
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public string CVV { get; set; }
		public string AdvertisementType { get; set; }




        public string UserId { get; set; }

		
		public User? User { get; set; }
	}

}
