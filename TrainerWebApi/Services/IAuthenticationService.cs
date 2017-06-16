using Microsoft.AspNet.Identity;
using TrainerWebApi.Models;

namespace TrainerWebApi.Services
{
    public interface IAuthenticationService
    {
        User Register(User user);
        User Login(User user);

        PasswordVerificationResult Authenticate(string username, string password);
    }
}