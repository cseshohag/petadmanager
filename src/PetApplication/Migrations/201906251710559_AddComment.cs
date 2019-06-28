namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(storeType: "ntext"),
                        CommentDate = c.DateTime(nullable: false),
                        PetAnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.PetAnimals", t => t.PetAnimalId, cascadeDelete: true)
                .Index(t => t.PetAnimalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PetAnimalId", "dbo.PetAnimals");
            DropIndex("dbo.Comments", new[] { "PetAnimalId" });
            DropTable("dbo.Comments");
        }
    }
}
