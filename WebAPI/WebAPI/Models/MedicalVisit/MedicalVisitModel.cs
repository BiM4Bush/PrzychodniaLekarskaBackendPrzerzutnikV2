using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MedicalVisitModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Guid DoctorId { get; set; }
        public string Reason { get; set; }
        public bool Confirmed { get; set; }
        public string DoctorRecommendation { get; set; }

    }
}