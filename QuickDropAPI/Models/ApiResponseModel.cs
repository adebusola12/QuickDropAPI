using QuickDropAPI.Services.Interface;
using QuickDropAPI.Services.Implementation;
namespace QuickDropAPI.Models
{
    public class ApiResponseModel
    {
        public string Body { get; set; }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
