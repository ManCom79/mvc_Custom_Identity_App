using mvc_Identity.Models;

namespace mvc_Identity.DataAccess.Interfaces
{
    public interface IDataTableRepository<T> where T : Base
    {
        public void Add(T entity);
        public T GetById(int Id);
        public List<T> GetAll();
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteById(int Id);
    }
}
