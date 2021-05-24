using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class MedicalVisitService : IMedicalVisitService
    {
        private readonly IMedicalVisitRepository _medicalVisitRepository;

        public MedicalVisitService(IMedicalVisitRepository medicalVisitRepository)
        {
            _medicalVisitRepository = medicalVisitRepository;
        }

        public async Task<int> Add(MedicalVisitModel visit)
        {
            return await _medicalVisitRepository.AddAsync(visit);
        }

        public async Task<int> Delete(Guid id)
        {
            var visit = await _medicalVisitRepository.GetAsync(id);
            return await _medicalVisitRepository.DeleteAsync(visit);
        }

        public async Task<IReadOnlyList<MedicalVisitModel>> Get()
        {
            return await _medicalVisitRepository.GetAsync();
        }

        public async Task<MedicalVisitModel> Get(Guid id)
        {
            return await _medicalVisitRepository.GetAsync(id);
        }
    }
}
