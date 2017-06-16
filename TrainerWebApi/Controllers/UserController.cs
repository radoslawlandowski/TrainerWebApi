using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainerWebApi.Models;
using TrainerWebApi.Repositories;
using TrainerWebApi.Services;

namespace TrainerWebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [Route("register")]
        public HttpResponseMessage Register(HttpRequestMessage message, User user)
        {
            _authenticationService.Register(user);

            return message.CreateResponse(HttpStatusCode.OK, "You have been registered!");
        }
    }
}