using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;
using WebAPI.Repositories.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public class MedicamentService : IMedicamentService
    {
        private readonly IMedicamentRepository _medicamentRepository;

        public MedicamentService(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }
        public async Task<int> Add(Medicament medicament)
        {
            return await _medicamentRepository.AddAsync(medicament);
        }

        public async Task<int> Delete(Guid id)
        {
            var medicament = await _medicamentRepository.GetAsync(id);
            return await _medicamentRepository.DeleteAsync(medicament);
        }

        public async Task<IReadOnlyList<Medicament>> Get()
        {
            return await _medicamentRepository.GetAsync();
        }

        public async Task<Medicament> Get(Guid id)
        {
            return await _medicamentRepository.GetAsync(id);
        }
    }
}
