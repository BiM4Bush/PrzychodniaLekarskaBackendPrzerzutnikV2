using System;
using System.Collections.Generic;
using System.Text;

namespace PLekarska.Core.Entities
{
    public class User : BaseEntity
    {
        public string emailAdress { get; set; }
        public string password { get; set; }
    }
}
