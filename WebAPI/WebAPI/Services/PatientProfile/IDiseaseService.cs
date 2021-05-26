using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.PatientProfile;

namespace WebAPI.Services.PatientProfile
{
    public interface IDiseaseService
    {
        Task<IReadOnlyList<Disease>> Get();
        Task<Disease> Get(Guid id);

        Task<int> Add(Disease disease);

        Task<int> Delete(Guid id);
    }
}
