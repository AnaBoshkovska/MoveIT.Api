using System.Threading.Tasks;
using System.Collections.Generic;

namespace MoveIT.Core.Repositories
{
    public interface IRepository<T, TKey> where T: class
    {
        Task<T> GetByIdAsync(TKey id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
