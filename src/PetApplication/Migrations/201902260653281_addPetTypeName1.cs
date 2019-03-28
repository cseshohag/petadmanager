namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPetTypeName1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PetTypeName", c => c.String());
            DropColumn("dbo.Pets", "PetTypeNameP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "PetTypeNameP", c => c.String());
            DropColumn("dbo.Pets", "PetTypeName");
        }
    }
}
