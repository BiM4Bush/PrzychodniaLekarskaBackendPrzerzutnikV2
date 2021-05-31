using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public class DiseaseRepository : IDiseaseRepository
    {
        protected readonly DiseaseContext DbContext;
        public DiseaseRepository(DiseaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> AddAsync(Disease entity)
        {
            await DbContext.Set<Disease>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Disease entity)
        {
            DbContext.Set<Disease>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<Disease> GetAsync(Guid id)
        {
            return await DbContext.Set<Disease>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Disease>> GetAsync()
        {
            return await DbContext.Set<Disease>().ToListAsync();
        }

        public async Task<int> UpdateAsync(Disease entity)
        {
           DbContext.Set<Disease>().Update(entity);
           return await DbContext.SaveChangesAsync();
        }
    }
}
