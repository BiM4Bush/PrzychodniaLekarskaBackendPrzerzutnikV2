using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.PatientProfile
{
    public class MedicamentContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public MedicamentContext(DbContextOptions<MedicamentContext> options) : base(options)
        {

        }
    }
}
