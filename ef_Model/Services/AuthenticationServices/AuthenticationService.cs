using Microsoft.AspNet.Identity;
using SimplerTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService accountService;
        private readonly IPasswordHasher hasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            this.accountService = accountService;
            hasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            var storedAccount = await accountService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            var passwordResult = hasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            var emailAccount = await accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            var userAccount = await accountService.GetByUsername(username);
            if (userAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success) {

                var hashedPW = hasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPW,
                    DateJoined = DateTime.Now
                };

                var account = new Account
                {
                    AccountHolder = user,
                };

                await accountService.Create(account);
            }

            return result;
        }
    }
}
