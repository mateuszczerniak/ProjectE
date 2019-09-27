namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Report", "Measurment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Report", "Measurment", c => c.String());
        }
    }
}
