using mvc_Identity.Data;
using mvc_Identity.DataAccess.Interfaces;
using mvc_Identity.Models;

namespace mvc_Identity.DataAccess.Implementations
{
    public class DataTableRepository<T> : IDataTableRepository<T> where T : Base
    {
        protected ApplicationDbContext _dbContext;
        public DataTableRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
