using Microsoft.EntityFrameworkCore;
using mvc_Identity.Data.Interfaces;
using mvc_Identity.Models;
using mvc_Identity.Data;
namespace mvc_Identity.Data.Implementations
{
	public class RentDataTableRepository : DataTableRepository<Rental>, IRentDataTableRepository
	{
		public RentDataTableRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
