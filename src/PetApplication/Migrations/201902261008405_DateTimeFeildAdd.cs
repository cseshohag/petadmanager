namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFeildAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PetPosts", "PostCreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PetPosts", "PostCreatedDate", c => c.String());
        }
    }
}
