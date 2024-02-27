using NUnit.Framework;
using Moq;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using RepositoryLayer.Entitys;
using CommonLayer.Model;
using BusinessLayer.Service;

namespace TestProject1
{
    public class UserBLTests
    {
        private Mock<IUserRL> mockUserRL;
        private IUserBL userBL;

        [SetUp]
        public void Setup()
        {
            mockUserRL = new Mock<IUserRL>();

            // Setup for Registration
            mockUserRL.Setup(repo => repo.Register(It.IsAny<UserModel>()))
                      .Returns(new UserEntity
                      {
                          UserId = 1,
                          UserEmail = "test@example.com",
                          UserPassword = "Test1234",
                          FristName = "Uddesh",
                          LastName = "Patil",
                          City = "xyz",
                          UserName = "UDDESHUP",
                          UserContact = "9876543210"
                      });

            // Setup for Login
            mockUserRL.Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>()))
                      .Returns("true") ; 

            userBL = new UserBL(mockUserRL.Object);
        }

        [Test]
        public void RegisterTest()
        {
            var newUser = new UserModel
            {
                UserEmail = "test@example.com",
                UserPassword = "Test1234",
                FirstName = "Uddesh",
                LastName = "Patil",
                City = "xyz",
                UserName = "UDDESHUP",
                UserContact = "9876543210"
            };

            var result = userBL.Register(newUser);

            Assert.IsNotNull(result);
            Assert.AreEqual("test@example.com", result.UserEmail);
            Assert.AreEqual("Test1234", result.UserPassword); // Note: Real implementation should not return passwords
            Assert.AreEqual("UDDESHUP", result.UserName);
            Assert.AreEqual("Uddesh", result.FristName);
            Assert.AreEqual("Patil", result.LastName);
            Assert.AreEqual("9876543210", result.UserContact);

            mockUserRL.Verify(repo => repo.Register(It.IsAny<UserModel>()), Times.Once);
        }

        [Test]
        public void LoginTest_Success()
        {
            string email = "test@example.com";
            string password = "Test1234";
                
            var result = userBL.Login(email, password);

            Assert.AreEqual("true",result); 

            mockUserRL.Verify(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

    }
}
