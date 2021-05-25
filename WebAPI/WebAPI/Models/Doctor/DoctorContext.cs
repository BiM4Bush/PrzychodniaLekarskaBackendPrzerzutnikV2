using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Doctor
{
    public class DoctorContext : DbContext
    {
        public DbSet<DoctorModel> Doctors{ get; set; }
        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options)
        {

        }
    }
}
