namespace ProjectE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        WorkSheetId = c.Int(nullable: false),
                        WorkReasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.WorkReason", t => t.WorkReasonId)
                .ForeignKey("dbo.WorkSheet", t => t.WorkSheetId)
                .Index(t => t.WorkSheetId)
                .Index(t => t.WorkReasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "WorkSheetId", "dbo.WorkSheet");
            DropForeignKey("dbo.Report", "WorkReasonId", "dbo.WorkReason");
            DropIndex("dbo.Report", new[] { "WorkReasonId" });
            DropIndex("dbo.Report", new[] { "WorkSheetId" });
            DropTable("dbo.Report");
        }
    }
}
