using Microsoft.EntityFrameworkCore;
using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Infrastructure.Persistance
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
