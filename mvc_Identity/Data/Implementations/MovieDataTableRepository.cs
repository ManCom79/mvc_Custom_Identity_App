using mvc_Identity.Data.Interfaces;
using mvc_Identity.Data.Implementations;
using mvc_Identity.Models;

namespace mvc_Identity.Data.Implementations
{
    public class MovieDataTableRepository : DataTableRepository<Movie>, IMovieDataTableRepository
    {
        public MovieDataTableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
