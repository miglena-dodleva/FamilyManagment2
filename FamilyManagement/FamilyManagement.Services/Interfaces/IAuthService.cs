using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IAuthService
    {
        List<string> AccessTokenGenerator(Credential credential);
        List<string> RefreshTokenGenerator(RefreshAccessToken model);
        bool RevokeToken(RefreshAccessToken model);

        User GetUserByCredentials(string username, string password); // Нов метод
    }
}
