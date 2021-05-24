using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MedicalVisitContext : DbContext
    {
        public DbSet<MedicalVisitModel> MedicalVisits { get; set; }
        public MedicalVisitContext(DbContextOptions options) : base(options)
        {

        }
    }
}
