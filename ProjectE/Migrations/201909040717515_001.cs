namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Installation", "Installation_InstallationId", "dbo.Installation");
            DropIndex("dbo.Installation", new[] { "Installation_InstallationId" });
            DropColumn("dbo.Installation", "Installation_InstallationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Installation", "Installation_InstallationId", c => c.Int());
            CreateIndex("dbo.Installation", "Installation_InstallationId");
            AddForeignKey("dbo.Installation", "Installation_InstallationId", "dbo.Installation", "InstallationId");
        }
    }
}
