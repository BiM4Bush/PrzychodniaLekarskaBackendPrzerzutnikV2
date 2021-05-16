using Microsoft.EntityFrameworkCore;
using PLekarska.Core;
using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Infrastructure.Persistance
{
    public class BaseRepository<T> : IAsyncRepository<T> where T
            : BaseEntity
    {
        protected readonly UserContext DbContext;

        public BaseRepository(UserContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}
