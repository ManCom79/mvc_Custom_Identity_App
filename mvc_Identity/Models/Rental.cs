namespace mvc_Identity.Models
{
	public class Rental : Base
	{
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public DateTime RentedOn { get; set; }
		public DateTime ReturnedOn { get; set; }
	}
}
