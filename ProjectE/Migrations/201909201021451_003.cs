namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Report", "InternalMeasurment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Report", "InternalMeasurment", c => c.String());
        }
    }
}
