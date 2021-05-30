using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using MoveIT.Core.Repositories;

namespace MoveIT.Data.Repositories
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly DbContext Context;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
             await Context.Set<T>().AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
