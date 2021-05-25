using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Doctor
{
    public interface IDoctorService
    {
        Task<IReadOnlyList<DoctorModel>> Get();
        Task<DoctorModel> Get(Guid id);

        Task<int> Add(DoctorModel doctor);

        Task<int> Delete(Guid id);
    }
}
