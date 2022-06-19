using ProductManagment.Contracts.Repositories;
using ProductManagment.Infrastructure.Data;
using System.Linq.Expressions;

namespace ProductManagment.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public CupBoardContext DataBaseContext { get; set; }

        public BaseRepository(CupBoardContext context) 
        {
            DataBaseContext = context;
        }


        public virtual IQueryable<T> GetAll()
        {
            var entitySet = DataBaseContext.Set<T>();
            return entitySet.AsQueryable();
        }

        public T QueryById(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate)!;
        }

        public async Task Create(T model)
        {
            await DataBaseContext.AddAsync(model);
            await DataBaseContext.SaveChangesAsync();
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public async Task Upload(T model)
        {
            DataBaseContext.Update(model);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            DataBaseContext.Remove(model);
            await DataBaseContext.SaveChangesAsync();
        }


    }
}
