namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        PetPostID = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.PetPosts", t => t.PetPostID, cascadeDelete: true)
                .Index(t => t.PetPostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostReports", "PetPostID", "dbo.PetPosts");
            DropIndex("dbo.PostReports", new[] { "PetPostID" });
            DropTable("dbo.PostReports");
        }
    }
}
