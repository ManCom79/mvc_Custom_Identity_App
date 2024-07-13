using Microsoft.EntityFrameworkCore;
using mvc_Identity.Data;
using mvc_Identity.Data.Interfaces;
using mvc_Identity.Models;

namespace mvc_Identity.Data.Implementations
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
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int Id)
        {
            var record = GetById(Id);
            Delete(record);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int Id)
        {
            var record = _dbContext.Set<T>().AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            if (record == null)
            {
                throw new Exception($"There is no record with id: {Id}");
            }
            return record;
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
