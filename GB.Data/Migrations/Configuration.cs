namespace GB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GB.Data.DAL.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GB.Data.DAL.ApplicationContext";
        }

        protected override void Seed(GB.Data.DAL.ApplicationContext context)
        {

        }
    }
}
