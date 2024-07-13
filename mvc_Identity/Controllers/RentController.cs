using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using mvc_Identity.Services.Interfaces;

namespace mvc_Identity.Controllers
{
	public class RentController : Controller
	{
		public IRentService _rentService;
		public RentController(IRentService rentService)
		{
			_rentService = rentService;
		}
		public IActionResult Index()
		{
			var userRentals = _rentService.GetUserRentals();
			return View(userRentals);
		}
		public IActionResult CreateRental(int id)
		{
			_rentService.CreateRental(id);
			return RedirectToAction("Index", "Movie");
		}

		public IActionResult DeleteRental(int id)
		{
			_rentService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
