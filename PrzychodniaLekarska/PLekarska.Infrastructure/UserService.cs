using System;
using System.Collections.Generic;
using System.Text;
using PLekarska.Core;

namespace PLekarska.Infrastructure
{
    public class UserService : IUserService
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(string user)
        {
            throw new NotImplementedException();
        }

        public List<string> Get()
        {
            return new List<string> { "UserTest123", "USer2", "User 3" };
        }
    }
}
