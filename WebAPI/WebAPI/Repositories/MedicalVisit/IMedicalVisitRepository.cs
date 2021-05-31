using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IMedicalVisitRepository
    {
        Task<MedicalVisitModel> GetAsync(Guid id);
        Task<IReadOnlyList<MedicalVisitModel>> GetAsync();
        Task<int> AddAsync(MedicalVisitModel entity);
        Task<int> DeleteAsync(MedicalVisitModel entity);
        Task<int> UpdateAsync(MedicalVisitModel entity);
    }
}
