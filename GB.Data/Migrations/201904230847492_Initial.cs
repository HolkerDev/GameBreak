namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRating",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ReleaseDate = c.DateTime(nullable: false),
                        ProductionID = c.Int(nullable: false),
                        GamePlatformID = c.Int(nullable: false),
                        AgeRatingID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AgeRating", t => t.AgeRatingID, cascadeDelete: false)
                .ForeignKey("dbo.GamePlatform", t => t.GamePlatformID, cascadeDelete: false)
                .ForeignKey("dbo.Production", t => t.ProductionID, cascadeDelete: false)
                .Index(t => t.ProductionID)
                .Index(t => t.GamePlatformID)
                .Index(t => t.AgeRatingID);
            
            CreateTable(
                "dbo.GameGenre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: false)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: false)
                .Index(t => t.GameID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GamePlatform",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductionGamePlatform",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GamePlatformID = c.Int(nullable: false),
                        ProductionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GamePlatform", t => t.GamePlatformID, cascadeDelete: false)
                .ForeignKey("dbo.Production", t => t.ProductionID, cascadeDelete: false)
                .Index(t => t.GamePlatformID)
                .Index(t => t.ProductionID);
            
            CreateTable(
                "dbo.Production",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GameCopy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        GameCopyStatusID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: false)
                .ForeignKey("dbo.GameCopyStatus", t => t.GameCopyStatusID, cascadeDelete: false)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.GameID)
                .Index(t => t.GameCopyStatusID)
                .Index(t => t.UserID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.GameCopyStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderGameCopy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameCopyID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GameCopy", t => t.GameCopyID, cascadeDelete: false)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: false)
                .Index(t => t.GameCopyID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiresAt = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: false)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.GameCopy", "UserID", "dbo.User");
            DropForeignKey("dbo.OrderGameCopy", "OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderGameCopy", "GameCopyID", "dbo.GameCopy");
            DropForeignKey("dbo.GameCopy", "LocationID", "dbo.Location");
            DropForeignKey("dbo.GameCopy", "GameCopyStatusID", "dbo.GameCopyStatus");
            DropForeignKey("dbo.GameCopy", "GameID", "dbo.Game");
            DropForeignKey("dbo.ProductionGamePlatform", "ProductionID", "dbo.Production");
            DropForeignKey("dbo.Game", "ProductionID", "dbo.Production");
            DropForeignKey("dbo.ProductionGamePlatform", "GamePlatformID", "dbo.GamePlatform");
            DropForeignKey("dbo.Game", "GamePlatformID", "dbo.GamePlatform");
            DropForeignKey("dbo.GameGenre", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.GameGenre", "GameID", "dbo.Game");
            DropForeignKey("dbo.Game", "AgeRatingID", "dbo.AgeRating");
            DropIndex("dbo.User", new[] { "RoleID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.OrderGameCopy", new[] { "OrderID" });
            DropIndex("dbo.OrderGameCopy", new[] { "GameCopyID" });
            DropIndex("dbo.GameCopy", new[] { "LocationID" });
            DropIndex("dbo.GameCopy", new[] { "UserID" });
            DropIndex("dbo.GameCopy", new[] { "GameCopyStatusID" });
            DropIndex("dbo.GameCopy", new[] { "GameID" });
            DropIndex("dbo.ProductionGamePlatform", new[] { "ProductionID" });
            DropIndex("dbo.ProductionGamePlatform", new[] { "GamePlatformID" });
            DropIndex("dbo.GameGenre", new[] { "GenreID" });
            DropIndex("dbo.GameGenre", new[] { "GameID" });
            DropIndex("dbo.Game", new[] { "AgeRatingID" });
            DropIndex("dbo.Game", new[] { "GamePlatformID" });
            DropIndex("dbo.Game", new[] { "ProductionID" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderGameCopy");
            DropTable("dbo.Location");
            DropTable("dbo.GameCopyStatus");
            DropTable("dbo.GameCopy");
            DropTable("dbo.Production");
            DropTable("dbo.ProductionGamePlatform");
            DropTable("dbo.GamePlatform");
            DropTable("dbo.Genre");
            DropTable("dbo.GameGenre");
            DropTable("dbo.Game");
            DropTable("dbo.AgeRating");
        }
    }
}
