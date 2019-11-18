using Medyana.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Data
{
    public class MedyanaContext : DbContext, IDisposable
    {
        public MedyanaContext(DbContextOptions<MedyanaContext> options) : base(options)
        {            
        }

        public virtual DbSet<MedClinic> MedClinic { get; set; }
        public virtual DbSet<MedEquipment> MedEquipment { get; set; }
        public virtual DbSet<ActionControllerLog> ActionControllerLog { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedClinic>().HasKey(f => f.Id);
            modelBuilder.Entity<MedEquipment>().HasKey(f => f.Id);
            modelBuilder.Entity<ActionControllerLog>().HasKey(f => f.Id);
            modelBuilder.Entity<ExceptionLog>().HasKey(f => f.Id);            
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }
    }

}
