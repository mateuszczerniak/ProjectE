namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "ToolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Report", "ToolId");
            AddForeignKey("dbo.Report", "ToolId", "dbo.Tool", "ToolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "ToolId", "dbo.Tool");
            DropIndex("dbo.Report", new[] { "ToolId" });
            DropColumn("dbo.Report", "ToolId");
        }
    }
}
