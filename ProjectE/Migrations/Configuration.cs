namespace ProjectE.Migrations
{
    using ProjectE.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectE.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectE.Models.Context context)
        {
            context.Loads.AddOrUpdate(x => x.LoadId,
                new Load() { LoadId = 1, Name = "DCS" },
                new Load() { LoadId = 2, Name = "KiA" }
                );
            context.DeviceTypes.AddOrUpdate(x => x.DeviceTypeId,
                new DeviceType() { DeviceTypeId = 1, Name = "UPS" },
                new DeviceType() { DeviceTypeId = 2, Name = "Zasilacz buforowy" },
                new DeviceType() { DeviceTypeId = 3, Name = "Przemiennik czêstotliwoœci" },
                new DeviceType() { DeviceTypeId = 4, Name = "Softstart" }
                );
            context.Manufacturers.AddOrUpdate(x => x.ManufacturerId,
                new Manufacturer() { ManufacturerId = 1, Name = "Medcom" },
                new Manufacturer() { ManufacturerId = 2, Name = "Hoppecke" },
                new Manufacturer() { ManufacturerId = 3, Name = "APS" },
                new Manufacturer() { ManufacturerId = 4, Name = "Siemens" }
                );
            context.BatterySpecies.AddOrUpdate(x => x.BatterySpeciesId,
                new BatterySpecies() { BatterySpeciesId = 1, Species = "Kwasowa" },
                new BatterySpecies() { BatterySpeciesId = 2, Species = "¯elowa" }
                );
            context.OperatingModes.AddOrUpdate(x => x.OperatingModeId,
                new OperatingMode() { OperatingModeId = 1, Name = "Pojedynczy" },
                new OperatingMode() { OperatingModeId = 2, Name = "Równoleg³y" }
                );
            context.Installations.AddOrUpdate(x => x.InstallationId,
                new Installation() { InstallationId = 1, ShortcutName = "DR2", Name = "Destylacja rurowo-wie¿owa 2" },
                new Installation() { InstallationId = 2, ShortcutName = "HOG", Name = "Hydroodsiarczanie gudronu" }
                );
        }
    }
}
