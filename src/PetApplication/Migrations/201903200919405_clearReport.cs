namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clearReport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostReports", "PetPostID", "dbo.PetPosts");
            DropIndex("dbo.PostReports", new[] { "PetPostID" });
            DropTable("dbo.PostReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostReports",
                c => new
                    {
                        PostReportID = c.Int(nullable: false, identity: true),
                        PetPostID = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.PostReportID);
            
            CreateIndex("dbo.PostReports", "PetPostID");
            AddForeignKey("dbo.PostReports", "PetPostID", "dbo.PetPosts", "PetPostID", cascadeDelete: true);
        }
    }
}
