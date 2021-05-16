using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Core
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
