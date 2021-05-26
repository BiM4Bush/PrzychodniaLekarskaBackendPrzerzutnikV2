using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public interface IPatientService
    {
        Task<IReadOnlyList<Patient>> Get();
        Task<Patient> Get(Guid id);

        Task<int> Add(Patient patient);

        Task<int> Delete(Guid id);
    }
}
