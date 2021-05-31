using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Doctor;

namespace WebAPI.Repositories.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        protected readonly DoctorContext DbContext;

        public DoctorRepository(DoctorContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> AddAsync(DoctorModel entity)
        {
            await DbContext.Set<DoctorModel>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(DoctorModel entity)
        {
            DbContext.Set<DoctorModel>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<DoctorModel> GetAsync(Guid id)
        {
            return await DbContext.Set<DoctorModel>().FindAsync(id);
        }

        public async Task<IReadOnlyList<DoctorModel>> GetAsync()
        {
            return await DbContext.Set<DoctorModel>().ToListAsync();
        }

        public async Task<int> UpdateAsync(DoctorModel entity)
        {
            DbContext.Set<DoctorModel>().Update(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}
