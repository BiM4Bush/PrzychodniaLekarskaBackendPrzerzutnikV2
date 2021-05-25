using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Doctor;

namespace WebAPI.Services.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<int> Add(DoctorModel doctor)
        {
            return await _doctorRepository.AddAsync(doctor);
        }

        public async Task<int> Delete(Guid id)
        {
            var doctor = await _doctorRepository.GetAsync(id);
            return await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<IReadOnlyList<DoctorModel>> Get()
        {
            return await _doctorRepository.GetAsync();
        }

        public async Task<DoctorModel> Get(Guid id)
        {
            return await _doctorRepository.GetAsync(id);
        }
    }
}
