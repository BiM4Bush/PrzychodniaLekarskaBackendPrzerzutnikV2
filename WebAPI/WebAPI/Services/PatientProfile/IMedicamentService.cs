using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public interface IMedicamentService
    {
        Task<IReadOnlyList<Medicament>> Get();
        Task<Medicament> Get(Guid id);

        Task<int> Add(Medicament medicament);

        Task<int> Delete(Guid id);
        Task<int> Update(Medicament medicament);
    }
}
