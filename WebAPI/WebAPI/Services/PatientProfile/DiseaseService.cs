using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;
using WebAPI.Repositories.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public async Task<int> Add(Disease disease)
        {
            return await _diseaseRepository.AddAsync(disease);
        }

        public async Task<int> Delete(Guid id)
        {
            var disease = await _diseaseRepository.GetAsync(id);
            return await _diseaseRepository.DeleteAsync(disease);
        }

        public async Task<IReadOnlyList<Disease>> Get()
        {
            return await _diseaseRepository.GetAsync();
        }

        public async Task<Disease> Get(Guid id)
        {
            return await _diseaseRepository.GetAsync(id);
        }
    }
}
