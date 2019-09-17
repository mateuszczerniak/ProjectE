namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "PowerFactor", c => c.Double(nullable: false));
            AddColumn("dbo.Report", "InputCurrentTHD", c => c.Double(nullable: false));
            AddColumn("dbo.Report", "OutputVoltageTHD", c => c.Double(nullable: false));
            AddColumn("dbo.Report", "Frequency", c => c.Int(nullable: false));
            AlterColumn("dbo.Report", "OutputVoltage", c => c.Double(nullable: false));
            AlterColumn("dbo.Report", "BufferVoltage", c => c.Double(nullable: false));
            AlterColumn("dbo.Report", "DensityBefore", c => c.Double(nullable: false));
            AlterColumn("dbo.Report", "DensityAfter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Report", "DensityAfter", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Report", "DensityBefore", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Report", "BufferVoltage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Report", "OutputVoltage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Report", "Frequency");
            DropColumn("dbo.Report", "OutputVoltageTHD");
            DropColumn("dbo.Report", "InputCurrentTHD");
            DropColumn("dbo.Report", "PowerFactor");
        }
    }
}
