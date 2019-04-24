namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCreatedByToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PetAnimals", "CreateBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PetAnimals", "CreateBy", c => c.Int(nullable: false));
        }
    }
}
