using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Data.DAL;
using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;

namespace GB.Data.Test
{
    /// <summary>
    /// Summary description for GameTest
    /// </summary>
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void AddGame()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                CreateGameDto game = new CreateGameDto()
                {
                    AgeRatingID = 2,
                    Description = "test description",
                    GamePlatformID = 3,
                    Name = "test game",
                    Price = 10,
                    ProductionID = 1,
                    ReleaseDate = DateTime.Now
                };

                GameRepository gameRepository = new GameRepository(context);
                Game gameDb = gameRepository.AddGame(game);

                Assert.AreEqual(gameDb.Name, gameDb.Name);
            };
        }

        [TestMethod]
        public void GetGame()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                GameRepository gameRepository = new GameRepository(context);
                GameDto gameDb = gameRepository.Get(18);
                Assert.AreEqual("test game", gameDb.Name);
            };
        }

    }
}
