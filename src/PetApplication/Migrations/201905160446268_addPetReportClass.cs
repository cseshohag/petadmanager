namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPetReportClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.PetAnimals", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetReports", "Id", "dbo.PetAnimals");
            DropIndex("dbo.PetReports", new[] { "Id" });
            DropTable("dbo.PetReports");
        }
    }
}
