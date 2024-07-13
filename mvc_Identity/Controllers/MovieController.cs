using Microsoft.AspNetCore.Mvc;
using mvc_Identity.Services.Interfaces;
using mvc_Identity.ViewModels;

namespace mvc_Identity.Controllers
{
    public class MovieController : Controller
    {
        public IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        public IActionResult CreateMovie()
        {
            var movie = new MovieViewModel();
            return View(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromForm] MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _movieService.CreateMovie(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var result = _movieService.GetDetails(id);
            return View(result);
        }

    }
}
