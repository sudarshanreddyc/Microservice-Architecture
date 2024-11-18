using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Controllers
{
    [Route("API/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Hardcoded credentials for simplicity
        private const string Username = "admin";
        private const string Password = "abcd1234";
        private const string SecretKey = "YourSuperSecretKey123456789012345"; // Keep this secure

        [HttpPost("ValidateUser")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Validate credentials
            if (loginRequest.Username == Username && loginRequest.Password == Password)
            {
                var token = GenerateJwtToken(loginRequest.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }

        [HttpGet("Verify")]
        public IActionResult Verify()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("Token is missing");
            }

            var token = authHeader.Substring("Bearer ".Length);

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SecretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "username").Value;

                return Ok(new { Message = "Token is valid", Username = username });
            }
            catch
            {
                return Unauthorized("Invalid token");
            }
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    // DTO for login request
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
