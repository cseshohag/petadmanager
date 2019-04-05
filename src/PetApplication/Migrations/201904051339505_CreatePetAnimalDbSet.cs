namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePetAnimalDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetAnimals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortCode = c.String(),
                        Age = c.Int(nullable: false),
                        Color = c.String(),
                        ImageUrl = c.String(),
                        Quantity = c.Int(nullable: false),
                        Details = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsSold = c.Boolean(nullable: false),
                        Area = c.String(),
                        City = c.String(),
                        Division = c.String(),
                        PetTypeID = c.Int(nullable: false),
                        PetTypeName = c.String(),
                        CreateBy = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetTypes", t => t.PetTypeID, cascadeDelete: true)
                .Index(t => t.PetTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetAnimals", "PetTypeID", "dbo.PetTypes");
            DropIndex("dbo.PetAnimals", new[] { "PetTypeID" });
            DropTable("dbo.PetAnimals");
        }
    }
}
