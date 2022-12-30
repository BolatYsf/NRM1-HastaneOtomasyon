using Hastane.DataAccess.EntityFramework.Mapping;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Context
{
    public class HastaneDbContext:DbContext
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options):base(options) // arka planda base option method ları calıstırır
        {

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonnelMapping());
            modelBuilder.ApplyConfiguration(new AdminMapping());
            modelBuilder.ApplyConfiguration(new ManagerMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
