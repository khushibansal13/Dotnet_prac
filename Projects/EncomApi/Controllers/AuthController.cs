using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EncomApi.Dtos.Auth;
using EncomApi.Interfaces;
using EncomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EncomApi.Controllers
{
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        
        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                ProfilePictureUrl = registerDto.ProfilePictureUrl
            };

            try {
                var registeredUser = await _userRepository.RegisterUserAsync(user, registerDto.Password);
                var token = GenerateJwtToken(registeredUser);
                return Ok(new AuthResponseDto
                {
                    Token = token,
                    Username = registeredUser.Username,
                    Email = registeredUser.Email,
                    ProfilePictureUrl = registeredUser.ProfilePictureUrl
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null || !_userRepository.VerifyPassword(user, loginDto.Password))
            {
                return Unauthorized("Invalid email or password");
            }

            var token = GenerateJwtToken(user);
            return Ok(new AuthResponseDto
            {
                Token = token,
                Username = user.Username,
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryInMinutes"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }               
    }
}