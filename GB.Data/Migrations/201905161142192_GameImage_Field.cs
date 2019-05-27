namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameImage_Field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "Image");
        }
    }
}
