using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int userId);

        User CreateUser(UserModel model);

        User EditUser(UserModel model, int userId);

        User DeleteUser(int userId);

    }
}
