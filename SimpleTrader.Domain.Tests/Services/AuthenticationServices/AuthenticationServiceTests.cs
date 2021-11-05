using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimplerTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> mockPasswordHasher;
        private Mock<IAccountService> mockAccountService;
        private AuthenticationService authenticationService;

        [SetUp]
        public void SetUp()
        {
            mockAccountService = new Mock<IAccountService>();
            mockPasswordHasher = new Mock<IPasswordHasher>();
            authenticationService =
                new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithTheCorrectPasswordForExistingUsername_ReturnsAccountForCorrectUsername()
        {
            // Arrange
            string expected = "testUser";
            string password = "testpassword";
            
            mockAccountService.Setup(s => s.GetByUsername(expected))
                .ReturnsAsync(
                new SimplerTrader.Domain.Models.Account() 
                { 
                    AccountHolder = new SimplerTrader.Domain.Models.User() 
                    { 
                        Username = expected 
                    } 
                });
            
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            // Act
            var account = await authenticationService.Login(expected, password);
            string actual = account.AccountHolder.Username;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Login_WithTheIncorrectPasswordForExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            // Arrange
            string expected = "testUser";
            string password = "testpassword";

            mockAccountService.Setup(s => s.GetByUsername(expected))
                .ReturnsAsync(
                new SimplerTrader.Domain.Models.Account()
                {
                    AccountHolder = new SimplerTrader.Domain.Models.User()
                    {
                        Username = expected
                    }
                });

            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            // Act
            var exception = Assert.ThrowsAsync<InvalidPasswordException>(() => authenticationService.Login(expected, password));
            string actualUsername = exception.Username;

            // Assert
            Assert.AreEqual(expected, actualUsername);
        }

        [Test]
        public void Login_WithNonExistingUsername_ThrowsUserNotFoundExceptionForUsername()
        {
            // Arrange
            string expected = "testUser";
            string password = "testpassword";

            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            // Act
            var exception = Assert.ThrowsAsync<UserNotFoundException>(() => authenticationService.Login(expected, password));
            string actualUsername = exception.Username;

            // Assert
            Assert.AreEqual(expected, actualUsername);
        }
         
        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            // arrange
            var password = "testPassword";
            var confirmedPassword = "testests";

            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            // act
            var actual = await authenticationService
                .Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmedPassword);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            var email = "test@gmail.com";

            // arrange
            mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            // act
            var actual = await authenticationService
                .Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            var username = "testuser";

            // arrange
            mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());

            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            // act
            var actual = await authenticationService
                .Register(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistingUsernameAndMatchingPassword_ReturnsSuccess()
        {
            // arrange
            RegistrationResult expected = RegistrationResult.Success;

            // act
            var actual = await authenticationService
                .Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
