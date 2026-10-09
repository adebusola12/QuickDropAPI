using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QuickDropAPI.Models;
using QuickDropAPI.Repository.Interface;
using QuickDropAPI.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickDropAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ApiResponseModel> RegisterAsync(RegisterModel request)
        {
            var existingUser =
                await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new ApiResponseModel
                {
                    StatusCode = 400,
                    Body = JsonConvert.SerializeObject(new
                    {
                        message = "Email already exists"
                    })
                };
            }

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new ApiResponseModel
            {
                StatusCode = 201,
                Body = JsonConvert.SerializeObject(new
                {
                    message = "Registration successful"
                })
            };
        }

        public async Task<ApiResponseModel> LoginAsync(LoginModel request)
        {
            var user =
                await _userRepository.GetByEmailAsync(request.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(
                    request.Password,
                    user.PasswordHash))
            {
                return new ApiResponseModel
                {
                    StatusCode = 401,
                    Body = JsonConvert.SerializeObject(new
                    {
                        message = "Invalid email or password"
                    })
                };
            }

            var token = GenerateToken(user);

            var response = new LoginResponseModel
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>("Jwt:DurationInMinutes")),
                Role = user.Role
            };

            return new ApiResponseModel
            {
                StatusCode = 200,
                Body = JsonConvert.SerializeObject(response)
            };
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,
                    $"{user.FirstName} {user.LastName}")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>(
                        "Jwt:DurationInMinutes")),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}