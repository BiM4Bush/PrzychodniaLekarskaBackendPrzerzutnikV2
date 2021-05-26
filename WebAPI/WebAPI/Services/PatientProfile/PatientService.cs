using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;
using WebAPI.Repositories.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<int> Add(Patient patient)
        {
            return await _patientRepository.AddAsync(patient);
        }

        public async Task<int> Delete(Guid id)
        {
            var patient = await _patientRepository.GetAsync(id);
            return await _patientRepository.DeleteAsync(patient);
        }

        public async Task<IReadOnlyList<Patient>> Get()
        {
            return await _patientRepository.GetAsync();
        }

        public async Task<Patient> Get(Guid id)
        {
            return await _patientRepository.GetAsync(id);
        }
    }
}
