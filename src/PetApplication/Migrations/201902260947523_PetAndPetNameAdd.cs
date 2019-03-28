namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetAndPetNameAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PetPosts", "PetName", c => c.String());
            CreateIndex("dbo.PetPosts", "PetID");
            AddForeignKey("dbo.PetPosts", "PetID", "dbo.Pets", "PetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetPosts", "PetID", "dbo.Pets");
            DropIndex("dbo.PetPosts", new[] { "PetID" });
            DropColumn("dbo.PetPosts", "PetName");
        }
    }
}
