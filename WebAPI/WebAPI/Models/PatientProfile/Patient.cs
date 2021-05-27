using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.PatientProfile
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; } //W tych czasach nawet nie można dać boolowskiej zmiennej if true -> mężczyzna if false -> kobieta :P 
        public int telNumber { get; set; }
        public string birthdayDate { get; set; }
        public string Adress { get; set; }
        public string PESEL { get; set; }
    }
}
