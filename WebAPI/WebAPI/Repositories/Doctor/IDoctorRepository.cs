using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Doctor
{
    public interface IDoctorRepository
    {
        Task<DoctorModel> GetAsync(Guid id);
        Task<IReadOnlyList<DoctorModel>> GetAsync();
        Task<int> AddAsync(DoctorModel entity);
        Task<int> DeleteAsync(DoctorModel entity);
        Task<int> UpdateAsync(DoctorModel entity);
    }
}
