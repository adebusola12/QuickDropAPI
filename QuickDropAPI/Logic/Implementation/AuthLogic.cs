using Newtonsoft.Json;
using QuickDropAPI.Logic.Interface;
using QuickDropAPI.Models;
using QuickDropAPI.Services.Implementation;
using QuickDropAPI.Services.Interface;
using System.Reflection.Metadata.Ecma335;
namespace QuickDropAPI.Logic.Implementation
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthService _authService;

        public AuthLogic(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ApiResponseModel> RegisterHandler(RegisterModel request)
        {
            return await _authService.RegisterAsync(request);
        }
         
        public async Task<ApiResponseModel> LoginHandler(LoginModel request)
        {
            return await _authService.LoginAsync(request);
        }
    }
}