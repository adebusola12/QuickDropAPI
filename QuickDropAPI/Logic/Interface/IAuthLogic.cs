using QuickDropAPI.Models;
using QuickDropAPI.Logic.Implementation;

namespace QuickDropAPI.Logic.Interface
{
    public interface IAuthLogic
    {
        Task<ApiResponseModel> RegisterHandler(RegisterModel request);
        Task<ApiResponseModel> LoginHandler(LoginModel request);

    }
}
