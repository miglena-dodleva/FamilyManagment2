using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Models.Auth
{
    public class RefreshAccessToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public string userId { get; set; } // new for login user info 

    }
}
