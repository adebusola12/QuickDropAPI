using QuickDropAPI.Models;

namespace QuickDropAPI.Services.Interface
{
    public interface IAuthService
    {
        Task<ApiResponseModel> RegisterAsync(RegisterModel request);
        Task<ApiResponseModel> LoginAsync(LoginModel request);
    }
}
