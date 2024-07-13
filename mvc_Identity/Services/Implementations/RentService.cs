using Microsoft.AspNetCore.Identity;
using mvc_Identity.Data.Interfaces;
using mvc_Identity.Mappers;
using mvc_Identity.Models;
using mvc_Identity.Services.Interfaces;
using mvc_Identity.ViewModels;
using NuGet.Protocol;
using System.Security.Claims;

namespace mvc_Identity.Services.Implementations
{
    public class RentService : IRentService
	{
		public IRentDataTableRepository _rentDataTableRepostitory;
		public IMovieDataTableRepository _movieDataTableRepository;
        private readonly HttpContext _httpContext;

        public RentService(IRentDataTableRepository rentDataTableRepostitory, IMovieDataTableRepository movieDataTableRepository, IHttpContextAccessor httpContextAccessor)
		{
			_rentDataTableRepostitory = rentDataTableRepostitory;
			_movieDataTableRepository = movieDataTableRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public void CreateRental(int id)
		{

			var loggedUserId = int.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

			if (!_rentDataTableRepostitory.GetAll().Any(x => x.MovieId == id && x.UserId == loggedUserId))
			{
				var movie = _movieDataTableRepository.GetById(id);
				movie.Quantity = movie.Quantity - 1;

				if (movie.Quantity == 0)
				{
					movie.IsAvailable = false;
				}

				_movieDataTableRepository.Update(movie);

				var rental = new Rental
				{
					MovieId = movie.Id,
					UserId = loggedUserId,
					RentedOn = DateTime.Now,
				};

				_rentDataTableRepostitory.Add(rental);
			};
		}

		public List<RentalViewModel> GetUserRentals()
		{
			var loggedUserId = int.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
			var rentals = _rentDataTableRepostitory.GetAll();
			var userRentals = rentals.Where(x => x.UserId == loggedUserId);

			var models = userRentals.Select(x => x.ToViewModel()).ToList();

			foreach (var model in models)
			{
				model.Title = _movieDataTableRepository.GetById(model.MovieId).Title;
			}

			return models;
		}
		public void Delete(int id)
		{
			var rental = _rentDataTableRepostitory.GetById(id);
			var movie = _movieDataTableRepository.GetById(rental.MovieId);
			movie.Quantity += 1;
			_movieDataTableRepository.Update(movie);

			_rentDataTableRepostitory.DeleteById(id);
		}
	}
}
