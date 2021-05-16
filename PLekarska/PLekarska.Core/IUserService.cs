using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Core
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> Get();
        Task<User> Get(Guid id);

        Task<int> Add(User user);

        Task<int> Delete(Guid id);
    }
}
