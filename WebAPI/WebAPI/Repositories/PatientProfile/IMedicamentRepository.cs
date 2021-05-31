using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public interface IMedicamentRepository
    {
        Task<Medicament> GetAsync(Guid id);
        Task<IReadOnlyList<Medicament>> GetAsync();
        Task<int> AddAsync(Medicament entity);
        Task<int> DeleteAsync(Medicament entity);
        Task<int> UpdateAsync(Medicament entity);
    }
}
