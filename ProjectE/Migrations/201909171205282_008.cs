namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _008 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FunctionalTest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FunctionalTest",
                c => new
                    {
                        FunctionalTestId = c.Int(nullable: false, identity: true),
                        StartStop = c.Boolean(nullable: false),
                        RegisterEntries = c.Boolean(nullable: false),
                        PrimarySupplyOff = c.Boolean(nullable: false),
                        PrimarySupplyBack = c.Boolean(nullable: false),
                        BypassSwitch = c.Boolean(nullable: false),
                        ShortCircuitTest = c.Boolean(nullable: false),
                        RapidLoadChanges = c.Boolean(nullable: false),
                        SignallingCheck = c.Boolean(nullable: false),
                        WorkCorrect = c.Boolean(nullable: false),
                        HousingCondition = c.Boolean(nullable: false),
                        WiringCondition = c.Boolean(nullable: false),
                        DisplayCondition = c.Boolean(nullable: false),
                        Cleaning = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FunctionalTestId);
            
        }
    }
}
