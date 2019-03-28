namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserTableName_ChangeUserIDName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "userInfo");
            RenameColumn(table: "dbo.userInfo", name: "Id", newName: "UserID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.userInfo", name: "UserID", newName: "Id");
            RenameTable(name: "dbo.userInfo", newName: "AspNetUsers");
        }
    }
}
