using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjectE.Models
{
    public class Context : DbContext
    {

        public Context() : base("Context")
        {
        }

        public DbSet<Battery> Batteries { get; set; }
        public DbSet<BatteryPack> BatteryPacks { get; set; }
        public DbSet<BatterySpecies> BatterySpecies { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { set; get; }
        public DbSet<DeviceModel> DeviceModels { set; get; }
        public DbSet<Installation> Installations { set; get; }
        public DbSet<Load> Loads { set; get; }
        public DbSet<Manufacturer> Manufacturers { set; get; }
        public DbSet<OperatingMode> OperatingModes { set; get; }
        //public DbSet<Owner> Owners { set; get; }
        public DbSet<Tool> Tools { set; get; }
        public DbSet<ToolType> ToolTypes { set; get; }
        public DbSet<WorkReason> WorkReasons { set; get; }
        public DbSet<WorkSheet> WorkSheets { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<FunctionalTest> FunctionalTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime"));
        }
    }
}