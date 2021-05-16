using PLekarska.Core;
using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Infrastructure.Persistance
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
        }
    }
}
