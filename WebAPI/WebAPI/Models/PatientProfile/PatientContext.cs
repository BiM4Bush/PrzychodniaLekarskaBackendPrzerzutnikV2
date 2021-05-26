using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.PatientProfile
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {

        }

    }
}
