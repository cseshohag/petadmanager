namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPetTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PetTypeNameP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "PetTypeNameP");
        }
    }
}
