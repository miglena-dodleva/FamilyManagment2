using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.AuthServices
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public List<string> GenerateToken(string claimValue)
        {
            var tokenModel = new RefreshAccessToken();

            // var keyEncoding = Encoding.UTF8.GetBytes("Random-Private-Key"); // Write what you want to use for encoding
            var keyEncoding = Encoding.UTF8.GetBytes("Random-Private-Key-With-Assistance-From-Magareto");
            var key = new SymmetricSecurityKey(keyEncoding);


            var claims = new Claim[]
            {
                new Claim("LoggedUserId", claimValue)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = new JwtSecurityToken
                (
                 // issure
                 "dev.company",
                 // audience
                 "management.react.webapi.project",
               // claims
               claims,
               // expires
               expires: DateTime.Now.AddMinutes(15),
               // signingCredentails
               signingCredentials: new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256Signature)
           );

            tokenModel.AccessToken = tokenHandler.WriteToken(token);
            tokenModel.RefreshToken = Guid.NewGuid().ToString();

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;

            var tokens = new List<string>
            {
                accessToken,
                refreshToken
            };

            return tokens;

        }
    }
}
