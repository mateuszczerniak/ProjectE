namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _008 : DbMigration
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
                .ForeignKey("dbo.BatterySpecies", t => t.BatterySpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
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
                        OwnerId = c.Int(nullable: false),
                        BatteryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BatteryPackId)
                .ForeignKey("dbo.Battery", t => t.BatteryId, cascadeDelete: true)
                .ForeignKey("dbo.Owner", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.BatteryId);
            
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
                        InstallationId = c.Int(nullable: false),
                        BatteryPackId = c.Int(nullable: false),
                        LoadId = c.Int(nullable: false),
                        OperatingModeId = c.Int(nullable: false),
                        DeviceModelId = c.Int(nullable: false),
                        DeviceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.BatteryPack", t => t.BatteryPackId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceModel", t => t.DeviceModelId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceType", t => t.DeviceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Installation", t => t.InstallationId, cascadeDelete: true)
                .ForeignKey("dbo.Load", t => t.LoadId, cascadeDelete: true)
                .ForeignKey("dbo.OperatingMode", t => t.OperatingModeId, cascadeDelete: true)
                .Index(t => t.InstallationId)
                .Index(t => t.BatteryPackId)
                .Index(t => t.LoadId)
                .Index(t => t.OperatingModeId)
                .Index(t => t.DeviceModelId)
                .Index(t => t.DeviceTypeId);
            
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
                        ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.DeviceModelId)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .Index(t => t.ManufacturerId);
            
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
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.ToolType", t => t.ToolTypeId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ToolTypeId);
            
            CreateTable(
                "dbo.ToolType",
                c => new
                    {
                        ToolTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ToolTypeId);
            
            CreateTable(
                "dbo.DeviceType",
                c => new
                    {
                        DeviceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeviceTypeId);
            
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
                "dbo.WorkSheet",
                c => new
                    {
                        WorkSheetId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        WorkReason_WorkReasonId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkSheetId)
                .ForeignKey("dbo.Device", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.WorkReason", t => t.WorkReason_WorkReasonId)
                .Index(t => t.DeviceId)
                .Index(t => t.WorkReason_WorkReasonId);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.BatterySpecies",
                c => new
                    {
                        BatterySpeciesId = c.Int(nullable: false, identity: true),
                        Species = c.String(),
                    })
                .PrimaryKey(t => t.BatterySpeciesId);
            
            CreateTable(
                "dbo.WorkReason",
                c => new
                    {
                        WorkReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WorkReasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSheet", "WorkReason_WorkReasonId", "dbo.WorkReason");
            DropForeignKey("dbo.Battery", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Battery", "BatterySpeciesId", "dbo.BatterySpecies");
            DropForeignKey("dbo.BatteryPack", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.WorkSheet", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Device", "OperatingModeId", "dbo.OperatingMode");
            DropForeignKey("dbo.Device", "LoadId", "dbo.Load");
            DropForeignKey("dbo.Device", "InstallationId", "dbo.Installation");
            DropForeignKey("dbo.Device", "DeviceTypeId", "dbo.DeviceType");
            DropForeignKey("dbo.Device", "DeviceModelId", "dbo.DeviceModel");
            DropForeignKey("dbo.DeviceModel", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Tool", "ToolTypeId", "dbo.ToolType");
            DropForeignKey("dbo.Tool", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Device", "BatteryPackId", "dbo.BatteryPack");
            DropForeignKey("dbo.BatteryPack", "BatteryId", "dbo.Battery");
            DropIndex("dbo.WorkSheet", new[] { "WorkReason_WorkReasonId" });
            DropIndex("dbo.WorkSheet", new[] { "DeviceId" });
            DropIndex("dbo.Tool", new[] { "ToolTypeId" });
            DropIndex("dbo.Tool", new[] { "ManufacturerId" });
            DropIndex("dbo.DeviceModel", new[] { "ManufacturerId" });
            DropIndex("dbo.Device", new[] { "DeviceTypeId" });
            DropIndex("dbo.Device", new[] { "DeviceModelId" });
            DropIndex("dbo.Device", new[] { "OperatingModeId" });
            DropIndex("dbo.Device", new[] { "LoadId" });
            DropIndex("dbo.Device", new[] { "BatteryPackId" });
            DropIndex("dbo.Device", new[] { "InstallationId" });
            DropIndex("dbo.BatteryPack", new[] { "BatteryId" });
            DropIndex("dbo.BatteryPack", new[] { "OwnerId" });
            DropIndex("dbo.Battery", new[] { "BatterySpeciesId" });
            DropIndex("dbo.Battery", new[] { "ManufacturerId" });
            DropTable("dbo.WorkReason");
            DropTable("dbo.BatterySpecies");
            DropTable("dbo.Owner");
            DropTable("dbo.WorkSheet");
            DropTable("dbo.OperatingMode");
            DropTable("dbo.Load");
            DropTable("dbo.Installation");
            DropTable("dbo.DeviceType");
            DropTable("dbo.ToolType");
            DropTable("dbo.Tool");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.DeviceModel");
            DropTable("dbo.Device");
            DropTable("dbo.BatteryPack");
            DropTable("dbo.Battery");
        }
    }
}