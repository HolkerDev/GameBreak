using System;
using GB.Data.DAL;
using GB.Data.Dto;
using GB.Data.Repositories;
using GB.Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GB.Data.Test
{

    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddUser()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UserDto user = new UserDto()
                {
                    BirthDate = DateTime.Now,
                    Email = "test@test.com",
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Password = "test",
                    PhoneNumber = "12345",
                    RoleID = 1,
                    Username = "testuser"
                };

                UserRepository userRepository = new UserRepository(context);
                User userDb = userRepository.AddUser(user);

                Assert.AreEqual(userDb.LastName, user.LastName);
            };  
        }

        [TestMethod]
        public void GetUser()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UserRepository userRepository = new UserRepository(context);
                UserDto userDb = userRepository.Get(4);
                Assert.AreEqual("Nowak", userDb.LastName);
            };
        }
    }
}
