namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "Measurment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Report", "Measurment");
        }
    }
}
