using System.Linq.Expressions;

namespace Uygulama2106.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);

    }
}
