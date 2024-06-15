using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class UserService : IUserService
    {
        private readonly FamilyManagementDbContext context;

        public UserService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<User> GetAllUsers()
        {
            var users = context.Users
                 .ToList();
            return users;
        }

        public User CreateUser(UserModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FamilyRole = model.FamilyRole
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public User GetUserById(int userId)
        {
            var user = context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            return user;
        }

        public User EditUser(UserModel model, int userId)
        {
            var user = GetUserById(userId);

            if (user == null)
            {
                return user;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Username = model.Username;
            user.Password = model.Password;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.FamilyRole = model.FamilyRole;

            context.Users.Update(user);
            context.SaveChanges();

            return user;
        }

        public User DeleteUser(int userId)
        {
            var user = GetUserById(userId);

            if (user == null)
            {
                return user;
            }

            context.Users.Remove(user);
            context.SaveChanges();

            return user;
        }

    }
}
