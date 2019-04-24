namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAgeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PetAnimals", "Age", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PetAnimals", "Age", c => c.Int(nullable: false));
        }
    }
}
