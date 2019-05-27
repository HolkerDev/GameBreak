using GB.Data.DAL;
using GB.Data.Repositories;
using GB.Data.Services;
using GB.Entities.Repositories;
using System;
using System.Data.Entity;
using Unity;

namespace GB.Web
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // TODO: Register your type's mappings here.
            container.RegisterType<DbContext,ApplicationContext>();

            container.RegisterType<IAgeRatingRepository, AgeRatingRepository>();
            container.RegisterType<IGameCopyRepository, GameCopyRepository>();
            container.RegisterType<IGameCopyStatusRepository, GameCopyStatusRepository>();
            container.RegisterType<IGameGenreRepository, GameGenreRepository>();
            container.RegisterType<IGamePlatformRepository, GamePlatformRepository>();
            container.RegisterType<IGameRepository, GameRepository>();
            container.RegisterType<IGenreRepository, GenreRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<IOrderGameCopyRepository, OrderGameCopyRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IProductionGamePlatformRepository, ProductionGamePlatformRepository>();
            container.RegisterType<IProductionRepository, ProductionRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IAgeRatingService, AgeRatingService>();
            container.RegisterType<IGameCopyService, GameCopyService>();
            container.RegisterType<IGameCopyStatusService, GameCopyStatusService>();
            container.RegisterType<IGameGenreService, GameGenreService>();
            container.RegisterType<IGamePlatformService, GamePlatformService>();
            container.RegisterType<IGameService, GameService>();
            container.RegisterType<IGenreService, GenreService>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<IOrderGameCopyService, OrderGameCopyService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductionGamePlatformService, ProductionGamePlatformService>();
            container.RegisterType<IProductionService, ProductionService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserService, UserService>();

        }
    }
}