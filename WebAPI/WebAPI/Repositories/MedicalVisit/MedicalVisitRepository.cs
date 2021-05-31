using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MedicalVisitRepository : IMedicalVisitRepository
    {
        protected readonly MedicalVisitContext DbContext;
        public MedicalVisitRepository(MedicalVisitContext dbContext) 
        {
            DbContext = dbContext;
        }
        public async Task<int> AddAsync(MedicalVisitModel entity)
        {
            await DbContext.Set<MedicalVisitModel>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(MedicalVisitModel entity)
        {
            DbContext.Set<MedicalVisitModel>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<MedicalVisitModel> GetAsync(Guid id)
        {
            return await DbContext.Set<MedicalVisitModel>().FindAsync(id);
        }

        public async Task<IReadOnlyList<MedicalVisitModel>> GetAsync()
        {
            return await DbContext.Set<MedicalVisitModel>().ToListAsync();
        }

        public async Task<int> UpdateAsync(MedicalVisitModel entity)
        {
            DbContext.Set<MedicalVisitModel>().Update(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}
