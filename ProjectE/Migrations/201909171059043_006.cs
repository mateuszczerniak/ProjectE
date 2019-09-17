namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Report", "FunctionalTestId", "dbo.FunctionalTest");
            DropIndex("dbo.Report", new[] { "FunctionalTestId" });
            AddColumn("dbo.Report", "StartStop", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "RegisterEntries", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "PrimarySupplyOff", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "PrimarySupplyBack", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "BypassSwitch", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "ShortCircuitTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "RapidLoadChanges", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "SignallingCheck", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "WorkCorrect", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "HousingCondition", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "WiringCondition", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "DisplayCondition", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "Cleaning", c => c.Boolean(nullable: false));
            DropColumn("dbo.Report", "FunctionalTestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Report", "FunctionalTestId", c => c.Int(nullable: false));
            DropColumn("dbo.Report", "Cleaning");
            DropColumn("dbo.Report", "DisplayCondition");
            DropColumn("dbo.Report", "WiringCondition");
            DropColumn("dbo.Report", "HousingCondition");
            DropColumn("dbo.Report", "WorkCorrect");
            DropColumn("dbo.Report", "SignallingCheck");
            DropColumn("dbo.Report", "RapidLoadChanges");
            DropColumn("dbo.Report", "ShortCircuitTest");
            DropColumn("dbo.Report", "BypassSwitch");
            DropColumn("dbo.Report", "PrimarySupplyBack");
            DropColumn("dbo.Report", "PrimarySupplyOff");
            DropColumn("dbo.Report", "RegisterEntries");
            DropColumn("dbo.Report", "StartStop");
            CreateIndex("dbo.Report", "FunctionalTestId");
            AddForeignKey("dbo.Report", "FunctionalTestId", "dbo.FunctionalTest", "FunctionalTestId");
        }
    }
}
