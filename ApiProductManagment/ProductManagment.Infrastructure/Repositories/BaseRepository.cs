using Microsoft.EntityFrameworkCore;
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

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate)!;
        }

        public virtual Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefaultAsync(predicate)!;
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
