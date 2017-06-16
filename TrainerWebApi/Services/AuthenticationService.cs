using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using TrainerWebApi.Exceptions;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;
using RegistrationException = TrainerWebApi.Exceptions.RegistrationException;

namespace TrainerWebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(User user)
        {
            User registeredUser = isRegistered(user.UserName);
            if (registeredUser != null)
            {
                throw new RegistrationException("This username is already registered in our database!");
            }
            else
            {
                user.PasswordHash = new PasswordHasher().HashPassword(user.PasswordHash);

                _userRepository.Add(user);
                return user;
            }
            
        }

        public User Login (User user)
        {
            return new User();
        }

        private User isRegistered(string username)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.UserName == username);
        }

        public PasswordVerificationResult Authenticate(string username, string password)
        {
            var user = isRegistered(username);

            return new PasswordHasher().VerifyHashedPassword(user.PasswordHash, password);
        }
     }
}