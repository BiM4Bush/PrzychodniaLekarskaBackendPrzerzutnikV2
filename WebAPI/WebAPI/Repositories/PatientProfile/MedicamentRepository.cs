using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public class MedicamentRepository : IMedicamentRepository
    {
        protected readonly MedicamentContext DbContext;
        public MedicamentRepository(MedicamentContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<int> AddAsync(Medicament entity)
        {
            await DbContext.Set<Medicament>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Medicament entity)
        {
            DbContext.Set<Medicament>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<Medicament> GetAsync(Guid id)
        {
            return await DbContext.Set<Medicament>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Medicament>> GetAsync()
        {
            return await DbContext.Set<Medicament>().ToListAsync();
        }
    }
}
