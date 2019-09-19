namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Battery",
                c => new
                    {
                        BatteryId = c.Int(nullable: false, identity: true),
                        BatteryType = c.String(),
                        Capacity = c.Single(nullable: false),
                        CellVoltage = c.Single(nullable: false),
                        CellQuantity = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        BatterySpeciesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BatteryId)
                .ForeignKey("dbo.BatterySpecies", t => t.BatterySpeciesId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.BatterySpeciesId);
            
            CreateTable(
                "dbo.BatteryPack",
                c => new
                    {
                        BatteryPackId = c.Int(nullable: false, identity: true),
                        ShortcutName = c.String(),
                        TechnologicalName = c.String(),
                        MonoblockNumber = c.Int(nullable: false),
                        StringNumber = c.Int(nullable: false),
                        DischargeCurrent1 = c.Single(nullable: false),
                        DischargeCurrent2 = c.Single(nullable: false),
                        DischargeCurrent3 = c.Single(nullable: false),
                        ProductionYear = c.DateTime(nullable: false),
                        AssemblyDate = c.DateTime(nullable: false),
                        LastReviewDate = c.DateTime(nullable: false),
                        BatteryId = c.Int(nullable: false),
                        InstallationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BatteryPackId)
                .ForeignKey("dbo.Battery", t => t.BatteryId)
                .ForeignKey("dbo.Installation", t => t.InstallationId)
                .Index(t => t.BatteryId)
                .Index(t => t.InstallationId);
            
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        ShortcutName = c.String(),
                        SerialNumber = c.String(),
                        PrimarySupply = c.String(),
                        SecondarySupply = c.String(),
                        ProductionYear = c.DateTime(nullable: false),
                        AssemblyDate = c.DateTime(nullable: false),
                        LastReviewDate = c.DateTime(nullable: false),
                        LastFunctionalTest = c.DateTime(nullable: false),
                        InstallationId = c.Int(nullable: false),
                        BatteryPackId = c.Int(nullable: false),
                        LoadId = c.Int(nullable: false),
                        OperatingModeId = c.Int(nullable: false),
                        DeviceModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.BatteryPack", t => t.BatteryPackId)
                .ForeignKey("dbo.DeviceModel", t => t.DeviceModelId)
                .ForeignKey("dbo.Installation", t => t.InstallationId)
                .ForeignKey("dbo.Load", t => t.LoadId)
                .ForeignKey("dbo.OperatingMode", t => t.OperatingModeId)
                .Index(t => t.InstallationId)
                .Index(t => t.BatteryPackId)
                .Index(t => t.LoadId)
                .Index(t => t.OperatingModeId)
                .Index(t => t.DeviceModelId);
            
            CreateTable(
                "dbo.DeviceModel",
                c => new
                    {
                        DeviceModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Power = c.Single(nullable: false),
                        InputVoltage = c.Single(nullable: false),
                        OutputVoltage = c.Single(nullable: false),
                        InputCurrent = c.Single(nullable: false),
                        OutputCurrent = c.Single(nullable: false),
                        InputPhaseNumber = c.Int(nullable: false),
                        OutputPhaseNumber = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        DeviceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceModelId)
                .ForeignKey("dbo.DeviceType", t => t.DeviceTypeId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.DeviceTypeId);
            
            CreateTable(
                "dbo.DeviceType",
                c => new
                    {
                        DeviceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeviceTypeId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Tool",
                c => new
                    {
                        ToolId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Model = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                        ToolTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToolId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.ToolType", t => t.ToolTypeId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ToolTypeId);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        WorkSheetId = c.Int(nullable: false),
                        WorkReasonId = c.Int(nullable: false),
                        ToolId = c.Int(nullable: false),
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
                        WorkTimeDay = c.DateTime(nullable: false),
                        WorkTimeFrom = c.DateTime(nullable: false),
                        WorkTimeTo = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Damage = c.String(),
                        ReplacedPart = c.String(),
                        FinalResult = c.String(),
                        Load = c.Int(nullable: false),
                        PowerFactor = c.Double(nullable: false),
                        InputCurrentTHD = c.Double(nullable: false),
                        OutputVoltageTHD = c.Double(nullable: false),
                        Frequency = c.Int(nullable: false),
                        OutputVoltage = c.Double(nullable: false),
                        BufferVoltage = c.Double(nullable: false),
                        BatteryTemperature = c.Int(nullable: false),
                        DensityBefore = c.Double(nullable: false),
                        DensityAfter = c.Double(nullable: false),
                        WaterAmount = c.Int(nullable: false),
                        BatteryHousing = c.Boolean(nullable: false),
                        BatteryJumper = c.Boolean(nullable: false),
                        BatteryCleaning = c.Boolean(nullable: false),
                        BatteryTest = c.DateTime(nullable: false),
                        BatteryStart = c.DateTime(nullable: false),
                        BatteryEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Tool", t => t.ToolId)
                .ForeignKey("dbo.WorkReason", t => t.WorkReasonId)
                .ForeignKey("dbo.WorkSheet", t => t.WorkSheetId)
                .Index(t => t.WorkSheetId)
                .Index(t => t.WorkReasonId)
                .Index(t => t.ToolId);
            
            CreateTable(
                "dbo.WorkReason",
                c => new
                    {
                        WorkReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WorkReasonId);
            
            CreateTable(
                "dbo.WorkSheet",
                c => new
                    {
                        WorkSheetId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkSheetId)
                .ForeignKey("dbo.Device", t => t.DeviceId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.ToolType",
                c => new
                    {
                        ToolTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ToolTypeId);
            
            CreateTable(
                "dbo.Installation",
                c => new
                    {
                        InstallationId = c.Int(nullable: false, identity: true),
                        ShortcutName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InstallationId);
            
            CreateTable(
                "dbo.Load",
                c => new
                    {
                        LoadId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LoadId);
            
            CreateTable(
                "dbo.OperatingMode",
                c => new
                    {
                        OperatingModeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OperatingModeId);
            
            CreateTable(
                "dbo.BatterySpecies",
                c => new
                    {
                        BatterySpeciesId = c.Int(nullable: false, identity: true),
                        Species = c.String(),
                    })
                .PrimaryKey(t => t.BatterySpeciesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Battery", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Battery", "BatterySpeciesId", "dbo.BatterySpecies");
            DropForeignKey("dbo.BatteryPack", "InstallationId", "dbo.Installation");
            DropForeignKey("dbo.Device", "OperatingModeId", "dbo.OperatingMode");
            DropForeignKey("dbo.Device", "LoadId", "dbo.Load");
            DropForeignKey("dbo.Device", "InstallationId", "dbo.Installation");
            DropForeignKey("dbo.Device", "DeviceModelId", "dbo.DeviceModel");
            DropForeignKey("dbo.DeviceModel", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Tool", "ToolTypeId", "dbo.ToolType");
            DropForeignKey("dbo.Report", "WorkSheetId", "dbo.WorkSheet");
            DropForeignKey("dbo.WorkSheet", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Report", "WorkReasonId", "dbo.WorkReason");
            DropForeignKey("dbo.Report", "ToolId", "dbo.Tool");
            DropForeignKey("dbo.Tool", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.DeviceModel", "DeviceTypeId", "dbo.DeviceType");
            DropForeignKey("dbo.Device", "BatteryPackId", "dbo.BatteryPack");
            DropForeignKey("dbo.BatteryPack", "BatteryId", "dbo.Battery");
            DropIndex("dbo.WorkSheet", new[] { "DeviceId" });
            DropIndex("dbo.Report", new[] { "ToolId" });
            DropIndex("dbo.Report", new[] { "WorkReasonId" });
            DropIndex("dbo.Report", new[] { "WorkSheetId" });
            DropIndex("dbo.Tool", new[] { "ToolTypeId" });
            DropIndex("dbo.Tool", new[] { "ManufacturerId" });
            DropIndex("dbo.DeviceModel", new[] { "DeviceTypeId" });
            DropIndex("dbo.DeviceModel", new[] { "ManufacturerId" });
            DropIndex("dbo.Device", new[] { "DeviceModelId" });
            DropIndex("dbo.Device", new[] { "OperatingModeId" });
            DropIndex("dbo.Device", new[] { "LoadId" });
            DropIndex("dbo.Device", new[] { "BatteryPackId" });
            DropIndex("dbo.Device", new[] { "InstallationId" });
            DropIndex("dbo.BatteryPack", new[] { "InstallationId" });
            DropIndex("dbo.BatteryPack", new[] { "BatteryId" });
            DropIndex("dbo.Battery", new[] { "BatterySpeciesId" });
            DropIndex("dbo.Battery", new[] { "ManufacturerId" });
            DropTable("dbo.BatterySpecies");
            DropTable("dbo.OperatingMode");
            DropTable("dbo.Load");
            DropTable("dbo.Installation");
            DropTable("dbo.ToolType");
            DropTable("dbo.WorkSheet");
            DropTable("dbo.WorkReason");
            DropTable("dbo.Report");
            DropTable("dbo.Tool");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.DeviceType");
            DropTable("dbo.DeviceModel");
            DropTable("dbo.Device");
            DropTable("dbo.BatteryPack");
            DropTable("dbo.Battery");
        }
    }
}
