namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntValueToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PetAnimals", "Quantity", c => c.String());
            AlterColumn("dbo.PetAnimals", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PetAnimals", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PetAnimals", "Quantity", c => c.Int(nullable: false));
        }
    }
}
