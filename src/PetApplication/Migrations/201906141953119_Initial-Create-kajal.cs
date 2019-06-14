namespace PetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreatekajal : DbMigration
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
                        PetTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.PetTypes", t => t.PetTypeID, cascadeDelete: true)
                .Index(t => t.PetTypeID);
            
            CreateTable(
                "dbo.PetTypes",
                c => new
                    {
                        PetTypeID = c.Int(nullable: false, identity: true),
                        PetTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PetTypeID);
            
            CreateTable(
                "dbo.PetAnimals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortCode = c.String(),
                        Age = c.String(),
                        Color = c.String(),
                        ImageUrl = c.String(),
                        Quantity = c.String(),
                        Details = c.String(),
                        Price = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsSold = c.Boolean(nullable: false),
                        Area = c.String(),
                        City = c.String(),
                        Division = c.String(),
                        PetTypeID = c.Int(nullable: false),
                        PetTypeName = c.String(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetTypes", t => t.PetTypeID, cascadeDelete: true)
                .Index(t => t.PetTypeID);
            
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
                        PostCreatedDate = c.DateTime(),
                        PetColor = c.String(),
                        PostStatus = c.String(),
                        PetName = c.String(),
                    })
                .PrimaryKey(t => t.PetPostID)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID);
            
            CreateTable(
                "dbo.PetReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.PetAnimals", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PostReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        PetPostID = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.PetPosts", t => t.PetPostID, cascadeDelete: true)
                .Index(t => t.PetPostID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.userInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.userInfo",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.userInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.userInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.userInfo");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.userInfo");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.userInfo");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostReports", "PetPostID", "dbo.PetPosts");
            DropForeignKey("dbo.PetReports", "Id", "dbo.PetAnimals");
            DropForeignKey("dbo.PetPosts", "PetID", "dbo.Pets");
            DropForeignKey("dbo.PetAnimals", "PetTypeID", "dbo.PetTypes");
            DropForeignKey("dbo.Pets", "PetTypeID", "dbo.PetTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.userInfo", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PostReports", new[] { "PetPostID" });
            DropIndex("dbo.PetReports", new[] { "Id" });
            DropIndex("dbo.PetPosts", new[] { "PetID" });
            DropIndex("dbo.PetAnimals", new[] { "PetTypeID" });
            DropIndex("dbo.Pets", new[] { "PetTypeID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.userInfo");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PostReports");
            DropTable("dbo.PetReports");
            DropTable("dbo.PetPosts");
            DropTable("dbo.PetAnimals");
            DropTable("dbo.PetTypes");
            DropTable("dbo.Pets");
        }
    }
}
