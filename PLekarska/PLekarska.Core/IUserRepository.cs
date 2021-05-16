using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLekarska.Core
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
