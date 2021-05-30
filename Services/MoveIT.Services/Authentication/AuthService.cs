using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

using MoveIT.Core.Models;
using MoveIT.Core.Services;

namespace MoveIT.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<User> userManager, IOptionsSnapshot<JwtSettings> jwtSettings, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            try
            {
                var user = _userManager.Users.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return null;

                var userSigninResult = await _userManager.CheckPasswordAsync(user, password);
                if (userSigninResult)
                {
                    return GenerateJwt(user);
                }

                return null;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to authenticate user with username {username}", username);
                return null;
            }
        }

        private string GenerateJwt(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
