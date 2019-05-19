using GB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Data.DAL
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext() : base("ApplicationContext") {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AgeRating> AgeRatings { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCopy> GameCopies { get; set; }
        public DbSet<GameCopyStatus> GameCopyStatuses { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderGameCopy> GetOrderGameCopies { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionGamePlatform> ProductionGamePlatforms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
