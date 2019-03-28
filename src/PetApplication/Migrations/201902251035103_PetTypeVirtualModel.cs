namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetTypeVirtualModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pets", "PetTypeID");
            AddForeignKey("dbo.Pets", "PetTypeID", "dbo.PetTypes", "PetTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetTypeID", "dbo.PetTypes");
            DropIndex("dbo.Pets", new[] { "PetTypeID" });
        }
    }
}
