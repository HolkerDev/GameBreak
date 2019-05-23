namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order_IsFinishedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "IsFinishedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "IsFinishedAt");
        }
    }
}
