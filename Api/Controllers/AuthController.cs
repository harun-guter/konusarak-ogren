using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public User Register(User user) => _authService.Register(user);

        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            bool checkUser = _authService.Login(user);
            return checkUser ? Ok(_authService.CreateAccessToken(user)) : BadRequest();
        }
    }
}
