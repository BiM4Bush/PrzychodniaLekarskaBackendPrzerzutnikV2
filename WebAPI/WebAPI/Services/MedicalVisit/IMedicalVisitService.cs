using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IMedicalVisitService
    {
        Task<IReadOnlyList<MedicalVisitModel>> Get();
        Task<MedicalVisitModel> Get(Guid id);

        Task<int> Add(MedicalVisitModel visit);

        Task<int> Delete(Guid id);
        Task<int> Update(MedicalVisitModel visit);
    }
}
