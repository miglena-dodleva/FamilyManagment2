using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class UserToFamilyService : IUserToFamilyService
    {
        private readonly FamilyManagementDbContext context;

        public UserToFamilyService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<UserToFamily> GetAllUserToFamilies()
        {
            var userToFamilies = context.UserToFamilies
                 .ToList();

            return userToFamilies;
        }

        public UserToFamily CreateUserToFamily(UserToFamilyModel model)
        {
            var userToFamily = new UserToFamily
            {
                UserId = model.UserId,
                FamilyId = model.FamilyId,
            };

            context.UserToFamilies.Add(userToFamily);
            context.SaveChanges();

            return userToFamily;
        }
        
        public UserToFamily GetUserToFamilyById(int id)
        {
            var userToFamily = context.UserToFamilies
                .Where(utf => utf.Id == id)
                .FirstOrDefault();

            return userToFamily;
        }

        public UserToFamily EditUserToFamily(UserToFamilyModel model, int id)
        {
            var userToFamily = GetUserToFamilyById(id); 

            if (userToFamily == null)
            {
                return userToFamily;
            }

            userToFamily.UserId = model.UserId;
            userToFamily.FamilyId = model.FamilyId;

            context.UserToFamilies.Update(userToFamily);
            context.SaveChanges();

            return userToFamily;
        }
        public UserToFamily DeleteUserToFamily(int id)
        {
            var userToFamily = GetUserToFamilyById(id);

            if (userToFamily == null)
            {
                return userToFamily;
            }

            context.UserToFamilies.Remove(userToFamily);
            context.SaveChanges();

            return userToFamily;

        }
    }
}
