using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickDropAPI.Logic.Interface;
using QuickDropAPI.Logic.Implementation;
using QuickDropAPI.Models;

namespace QuickDropAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthLogic _authLogic;

        public AuthController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            ApiResponseModel response = await _authLogic.RegisterHandler(request);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            ApiResponseModel response = await _authLogic.LoginHandler(request);
                return StatusCode (response.StatusCode, response);
        }
    }
}
