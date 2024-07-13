namespace mvc_Identity.ViewModels
{
	public class RentalViewModel
	{
		public int Id { get; set; }
		public int MovieId { get; set; }
		public string Title { get; set; }
		public int UserId { get; set; }
		public DateTime RentedOn { get; set; }
		public DateTime ReturnedOn { get; set; }
	}
}
