using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PowerStation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PowerStation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _context.Users
                .Include(user => user.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null ||
                !VerifyPassword(model.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("123456789123456789123456789123456789123456789");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch
            {
                return false;
            }
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
