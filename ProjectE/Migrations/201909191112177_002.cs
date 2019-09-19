namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "InternalMeasurment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Report", "InternalMeasurment");
        }
    }
}
