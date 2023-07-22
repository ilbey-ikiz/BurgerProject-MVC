using BurgerProject_MVC_G4.Data;
using System.Linq.Expressions;
using Uygulama2106.Repository.Abstract;

namespace Uygulama2106.Repository.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Add(T entity)
        {
            try
            {
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges() > 0;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public bool Update(T entity)
        {
            try
            {
                dbContext.Set<T>().Update(entity);
                return dbContext.SaveChanges() > 0;
            }
            catch 
            {
                return false;
            }
        }
    }
}
