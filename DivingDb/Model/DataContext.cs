using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DivingDb.Model
{
    public class DataContext: DbContext
    {

        public DbSet<DivingLabor> DivingLabors { get; set; }
        public DbSet<DivingActivity> DivingActivities { get; set; }
        public DbSet<DivingActivityDetail> DivingActivityDetails { get; set; }
        public DbSet<DivingTypeJob> DivingTypeJobs { get; set; }
        public DbSet<DivingTypeSubJob> DivingTypeSubJobs { get; set; }
        public DbSet<Diver> Divers { get; set; }
        public DbSet<DeepTable> DeepTables { get; set; }
        public DbSet<DeepGroup> DeepGroups { get; set; }
        public DbSet<DiveTypePermission> DiveTypePermissions { get; set; }
        public DbSet<DivingTimePeriod> DivingTimePeriods { get; set; }
        public DbSet<DivingEquipment> DivingEquipments { get; set; }
        public DbSet<DivingEquipmentCategory> DivingEquipmentCategories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PCRMARTINEZ\\SQL2016;Database=DivingDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DivingLaborConfiguration());
            modelBuilder.ApplyConfiguration(new DivingActivityConfiguration());
            modelBuilder.ApplyConfiguration(new DivingActivityDetailConfiguration());
            modelBuilder.ApplyConfiguration(new DivingEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new DivingTypeJobConfiguration());
            modelBuilder.ApplyConfiguration(new DivingTypeSubJobConfiguration());
            modelBuilder.ApplyConfiguration(new DiverConfiguration());
            modelBuilder.ApplyConfiguration(new DeepTableConfiguration());
            modelBuilder.ApplyConfiguration(new DeepGroupConfiguration());
            modelBuilder.ApplyConfiguration(new DiveTypePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new DivingTimePeriodConfiguration());
            modelBuilder.ApplyConfiguration(new DivingEquipmentCategoryConfiguration());
        }

    }
}
