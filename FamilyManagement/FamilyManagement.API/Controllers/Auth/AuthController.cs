using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("token")]
        public IActionResult Token(Credential model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }
            
            //
            var loggedUser = this.service.GetUserByCredentials(model.Username, model.Password);

            if (loggedUser == null)
            {
                return Unauthorized();
            }
            //

            var tokens = this.service.AccessTokenGenerator(model);

            if (tokens == null)
            {
                NotFound();
            }

            var readAccessToken = tokens[0];
            var readRefreshToken = tokens[1];


            return Ok(new
            {
                accessToken = readAccessToken,
                refreshToken = readRefreshToken,
                userId = loggedUser.Id
            });

        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(RefreshAccessToken model)
        {

            var tokens = this.service.RefreshTokenGenerator(model);

            if (tokens == null)
            {
                return Unauthorized();
            }

            var readAccessToken = tokens[0];
            var readRefreshToken = tokens[1];

            return Ok(new
            {
                accessToken = readAccessToken,
                refreshToken = readRefreshToken
            });
        }

        [HttpPost("revoke")]
        public IActionResult RevokeToken(RefreshAccessToken model)
        {
            var isTokenRevoked = this.service.RevokeToken(model);

            if (!isTokenRevoked)
            {
                return Unauthorized();
            }

            return NoContent();
        }
    }

}
