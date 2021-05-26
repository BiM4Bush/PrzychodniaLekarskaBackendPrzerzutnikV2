using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.PatientProfile
{
    public class DiseaseContext : DbContext
    {
        public DbSet<Disease> Diseases { get; set; }
        public DiseaseContext(DbContextOptions<DiseaseContext> options) : base(options)
        {

        }
    }
}
