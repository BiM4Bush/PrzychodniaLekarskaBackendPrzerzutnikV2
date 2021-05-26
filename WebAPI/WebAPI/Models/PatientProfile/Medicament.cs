using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.PatientProfile
{
    public class Medicament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
