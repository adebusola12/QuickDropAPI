using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace QuickDropAPI.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Role { get; set; }

        public string Message { get; set; }
    }
}
