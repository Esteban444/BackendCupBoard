using System.Linq.Expressions;

namespace ProductManagment.Contracts.Repositories
{
    public interface IBaseRepository<T> 
    {
        IQueryable<T> GetAll();
        T QueryById(Expression<Func<T, bool>> predicate);
        IQueryable<T> QueryBy(Expression<Func<T, bool>> predicate);
        Task Create(T model);
        Task Upload(T model);
        Task Delete(T model);
    }
}
