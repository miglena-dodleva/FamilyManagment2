using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IUserToFamilyService
    {
        List<UserToFamily> GetAllUserToFamilies();

        UserToFamily GetUserToFamilyById(int id);
        
        UserToFamily CreateUserToFamily(UserToFamilyModel model);
        
        UserToFamily EditUserToFamily(UserToFamilyModel model, int id);
        
        UserToFamily DeleteUserToFamily(int id);
    }
}
