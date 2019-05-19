namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameCopy_NullableUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameCopy", "UserID", "dbo.User");
            DropIndex("dbo.GameCopy", new[] { "UserID" });
            AlterColumn("dbo.GameCopy", "UserID", c => c.Int());
            CreateIndex("dbo.GameCopy", "UserID");
            AddForeignKey("dbo.GameCopy", "UserID", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameCopy", "UserID", "dbo.User");
            DropIndex("dbo.GameCopy", new[] { "UserID" });
            AlterColumn("dbo.GameCopy", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.GameCopy", "UserID");
            AddForeignKey("dbo.GameCopy", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
