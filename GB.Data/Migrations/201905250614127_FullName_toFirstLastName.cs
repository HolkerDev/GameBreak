namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullName_toFirstLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.User", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
