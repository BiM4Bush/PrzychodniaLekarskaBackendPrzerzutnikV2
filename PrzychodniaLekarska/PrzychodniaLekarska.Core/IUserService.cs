using System;
using System.Collections.Generic;
using System.Text;

namespace PLekarska.Core
{
    public interface IUserService
    {
        List<string> Get();
        void Add();
        void Delete(string user);
    }
}
