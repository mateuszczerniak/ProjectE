namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "FunctionalTestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Report", "FunctionalTestId");
            AddForeignKey("dbo.Report", "FunctionalTestId", "dbo.FunctionalTest", "FunctionalTestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "FunctionalTestId", "dbo.FunctionalTest");
            DropIndex("dbo.Report", new[] { "FunctionalTestId" });
            DropColumn("dbo.Report", "FunctionalTestId");
        }
    }
}
