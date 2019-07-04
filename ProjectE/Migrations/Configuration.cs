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
        }
    }
}
