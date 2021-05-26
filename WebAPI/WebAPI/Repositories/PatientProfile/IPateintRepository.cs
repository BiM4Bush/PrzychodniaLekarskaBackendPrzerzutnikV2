using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Repositories.PatientProfile
{
    public interface IPatientRepository
    {
        Task<Patient> GetAsync(Guid id);
        Task<IReadOnlyList<Patient>> GetAsync();
        Task<int> AddAsync(Patient entity);
        Task<int> DeleteAsync(Patient entity);
    }
}
