using mvc_Identity.ViewModels;

namespace mvc_Identity.Services.Interfaces
{
    public interface IMovieService
    {
        public void CreateMovie(MovieViewModel movieModel);
        public MovieViewModel GetDetails(int id);
        public List<MovieViewModel> GetAll();
    }
}
