using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public class PatientRepository : IPatientRepository
    {
        protected readonly PatientContext DbContext;
        public PatientRepository(PatientContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<int> AddAsync(Patient entity)
        {
            await DbContext.Set<Patient>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Patient entity)
        {
            DbContext.Set<Patient>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<Patient> GetAsync(Guid id)
        {
            return await DbContext.Set<Patient>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Patient>> GetAsync()
        {
            return await DbContext.Set<Patient>().ToListAsync();
        }
    }
}
