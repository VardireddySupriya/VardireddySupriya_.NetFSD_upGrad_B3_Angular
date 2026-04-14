
using backend_mini_project1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend_mini_project1.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // REGISTER
        public async Task<UserResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser != null)
                throw new ApplicationException("Email already registered");

            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),

                // FIX: normalize role
                Role = string.IsNullOrWhiteSpace(dto.Role)
                    ? "User"
                    : char.ToUpper(dto.Role.Trim()[0]) + dto.Role.Trim().Substring(1).ToLower()
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserResponseDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        // LOGIN
        public async Task<object> LoginAsync(LoginDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                throw new ApplicationException("User not found");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new ApplicationException("Invalid password");

            var token = GenerateToken(user);

            return new
            {
                message = "Login successful",
                token,
                user = new UserResponseDTO
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                }
            };
        }

        // TOKEN GENERATION (FIXED)
        private string GenerateToken(Users user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            //  FIX: consistent role format
            var role = string.IsNullOrWhiteSpace(user.Role)
                ? "User"
                : char.ToUpper(user.Role.Trim()[0]) + user.Role.Trim().Substring(1).ToLower();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, role) // ✅ FIXED ROLE ISSUE
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_config["Jwt:DurationInMinutes"])
                ),
                signingCredentials: new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
