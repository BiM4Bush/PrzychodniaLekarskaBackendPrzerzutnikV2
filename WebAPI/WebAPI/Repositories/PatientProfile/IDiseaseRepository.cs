using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public interface IDiseaseRepository
    {
        Task<Disease> GetAsync(Guid id);
        Task<IReadOnlyList<Disease>> GetAsync();
        Task<int> AddAsync(Disease entity);
        Task<int> DeleteAsync(Disease entity);
        Task<int> UpdateAsync(Disease entity);
    }
}
