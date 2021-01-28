using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository<T>
    {
        bool Delete(int Id);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int Id);
    }
}
