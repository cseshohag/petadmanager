namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPet_TYPE_PET_POST : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        PetTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetID);
            
            CreateTable(
                "dbo.PetPosts",
                c => new
                    {
                        PetPostID = c.Int(nullable: false, identity: true),
                        PetID = c.Int(nullable: false),
                        PetPrice = c.Int(nullable: false),
                        PetDetails = c.String(),
                        PetImageUrl = c.String(),
                        PetLocation = c.String(),
                        PostCreatedDate = c.String(),
                        PetColor = c.String(),
                        PostStatus = c.String(),
                    })
                .PrimaryKey(t => t.PetPostID);
            
            CreateTable(
                "dbo.PetTypes",
                c => new
                    {
                        PetTypeID = c.Int(nullable: false, identity: true),
                        PetTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PetTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PetTypes");
            DropTable("dbo.PetPosts");
            DropTable("dbo.Pets");
        }
    }
}
