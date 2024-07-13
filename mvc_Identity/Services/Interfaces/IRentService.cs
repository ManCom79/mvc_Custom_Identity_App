using mvc_Identity.ViewModels;
using mvc_Identity.Models;
namespace mvc_Identity.Services.Interfaces
{
	public interface IRentService
	{
		public void CreateRental(int id);
		public List<RentalViewModel> GetUserRentals();
		public void Delete(int id);
	}
}
