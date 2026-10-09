using QuickDropAPI.Models;
namespace QuickDropAPI.Services.Interface
{
    public interface ICustomService
    {
        Task<ApiResponseModel> MakeHttpCall(object request, string baseURL, string requestURL, HttpMethod method, Dictionary<string, string> headers);
    }
}
