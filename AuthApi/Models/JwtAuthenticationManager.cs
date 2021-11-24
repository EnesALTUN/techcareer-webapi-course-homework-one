using AuthApi.Infrastructure;
using Core.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Models
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IOptions<JwtSettings> _jwtConfiguration;

        public JwtAuthenticationManager(IOptions<JwtSettings> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }

        public dynamic TokenHandler(string email)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfiguration.Value.Security));
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,
                ValidateIssuer = true,
                ValidIssuer = _jwtConfiguration.Value.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtConfiguration.Value.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };
            DateTime now = DateTime.UtcNow;
            JwtSecurityToken jwt = new JwtSecurityToken(
                     issuer: _jwtConfiguration.Value.Issuer,
                     audience: _jwtConfiguration.Value.Audience,
                     claims: new List<Claim> {
                        new Claim(ClaimTypes.Email, email)
                     },
                     notBefore: now,
                     expires: now.Add(TimeSpan.FromHours(2)),
                     signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                 );
            return new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                Expires = TimeSpan.FromHours(2).TotalSeconds
            };
        }
    }
}
