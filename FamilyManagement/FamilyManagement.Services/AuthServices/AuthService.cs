using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Models.Entities;
using FamilyManagement.Models.Enums;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.Auth;

namespace FamilyManagement.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly FamilyManagementDbContext context;
        private readonly ITokenGeneratorService generatorService;
        private readonly List<string> tokens;

        public AuthService(FamilyManagementDbContext context, ITokenGeneratorService generatorService)
        {
            this.context = context;
            this.generatorService = generatorService;
            tokens = new List<string>();
        }

        public List<string> AccessTokenGenerator(Credential credential)
        {
            var usernameFromModel = credential.Username;

            var passwordFromModel = credential.Password;

            var loggedUser = context.Users
               .Where(x => x.Username == usernameFromModel && x.Password == passwordFromModel)
               .FirstOrDefault();

            if (loggedUser == null)
            {
                return new List<string>();
            }

            var loggedUserId = loggedUser.Id;

            var tokens = generatorService.GenerateToken(loggedUserId.ToString());


            var readAccessToken = tokens[0];

            var activeJwtTokenStatus = JwtTokenStatus.Active;

            var accessToken = new JwtToken()
            {
                Token = readAccessToken,
                CreatedOn = DateTime.Now,
                CreatedBy = loggedUserId,
                Status = activeJwtTokenStatus
            };

            var readRefreshToken = tokens[1];

            var pendingRefreshTokenStatus = RefreshTokenStatus.Pending;

            var refreshToken = new RefreshToken()
            {
                Token = readRefreshToken,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = loggedUserId,
                Status = pendingRefreshTokenStatus
            };

            var accessTokens = context.JwtTokens
                .Where(x => x.Status == activeJwtTokenStatus
                    && x.CreatedBy == loggedUserId)
                .ToList();

            var revokedJwtTokenStatus = JwtTokenStatus.Revoked;

            foreach (var item in accessTokens)
            {
                item.Status = revokedJwtTokenStatus;
            }

            var refreshTokens = context.RefreshTokens
                  .Where(x => x.Status == pendingRefreshTokenStatus
                      && x.CreatedBy == loggedUserId)
                  .ToList();

            var revokedRefreshTokenStatus = RefreshTokenStatus.Revoked;

            foreach (var item in refreshTokens)
            {
                item.Status = revokedRefreshTokenStatus;
            }


            context.JwtTokens.Add(accessToken);
            context.RefreshTokens.Add(refreshToken);
            context.SaveChanges();

            this.tokens.Add(readAccessToken);
            this.tokens.Add(readRefreshToken);

            return this.tokens;
        }

        public List<string> RefreshTokenGenerator(RefreshAccessToken model)
        {
            var refreshTokenFromModel = model.RefreshToken;

            var requesterRefreshToken = context.RefreshTokens
                .Where(x => x.Token == refreshTokenFromModel)
                .FirstOrDefault();

            var pendingRefreshTokenStatus = RefreshTokenStatus.Pending;
            var statusOfRequestRefreshToken = requesterRefreshToken.Status;

            if (statusOfRequestRefreshToken != pendingRefreshTokenStatus)
            {
                return new List<string>();
            }

            var idOfRquesterRefreshToken = requesterRefreshToken.Id.ToString();

            var tokens = generatorService.GenerateToken(idOfRquesterRefreshToken);


            var readAccessToken = tokens[0];

            var creatorOfRefreshToken = requesterRefreshToken.CreatedBy;

            var activeJwtTokenStatus = JwtTokenStatus.Active;

            var accessToken = new JwtToken()
            {
                Token = readAccessToken,
                CreatedOn = DateTime.Now,
                CreatedBy = creatorOfRefreshToken,
                Status = activeJwtTokenStatus
            };

            var readRefreshToken = tokens[1];

            var refreshToken = new RefreshToken()
            {
                Token = readRefreshToken,
                CreatedOn = DateTime.Now,
                CreatedBy = creatorOfRefreshToken,
                Status = pendingRefreshTokenStatus
            };

            var refreshTokens = context.RefreshTokens
                   .Where(x => x.Status == pendingRefreshTokenStatus
                       && x.CreatedBy == creatorOfRefreshToken)
                   .ToList();

            var accessTokens = context.JwtTokens
                .Where(x => x.Status == activeJwtTokenStatus
                    && x.CreatedBy == creatorOfRefreshToken)
                .ToList();

            var revokedJwtTokenStatus = JwtTokenStatus.Revoked;

            foreach (var item in accessTokens)
            {
                item.Status = revokedJwtTokenStatus;
            }

            var revokedRefreshTokenStatus = RefreshTokenStatus.Revoked;

            foreach (var item in refreshTokens)
            {
                item.Status = revokedRefreshTokenStatus;
            }

            context.JwtTokens.Add(accessToken);
            context.RefreshTokens.Add(refreshToken);

            context.SaveChanges();

            this.tokens.Add(readAccessToken);
            this.tokens.Add(readRefreshToken);

            return this.tokens;

        }

        public bool RevokeToken(RefreshAccessToken model)
        {
            var accessTokenFromModel = model.AccessToken;

            var requesterAccessToken = context.JwtTokens
               .Where(x => x.Token == accessTokenFromModel)
               .FirstOrDefault();

            var statusOfRequestAccessToken = requesterAccessToken.Status;

            var activeJwtTokenStatus = JwtTokenStatus.Active;

            if (statusOfRequestAccessToken != activeJwtTokenStatus)
            {
                return false;
            }

            var creatorOfRequesterccessToken = requesterAccessToken.CreatedBy;

            var refreshTokens = context.RefreshTokens
                              .Where(x => x.CreatedBy == creatorOfRequesterccessToken)
                              .ToList();

            var revokedRefreshTokenStatus = RefreshTokenStatus.Revoked;

            foreach (var item in refreshTokens)
            {
                item.Status = revokedRefreshTokenStatus;
            }

            context.SaveChanges();

            return true;

        }

        public User GetUserByCredentials(string username, string password)
        {
            var user = context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }
    }
}
