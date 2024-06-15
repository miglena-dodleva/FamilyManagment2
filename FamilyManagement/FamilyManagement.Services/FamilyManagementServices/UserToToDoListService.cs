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
    public class UserToToDoListService : IUserToToDoListService
    {
        private readonly FamilyManagementDbContext context;

        public UserToToDoListService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<UserToToDoList> GetAllUserToToDoLists()
        {
            var userToToDoLists = context.UserToToDoLists
                .ToList();

            return userToToDoLists;
        }

        public UserToToDoList CreateUserToToDoList(UserToToDoListModel model)
        {
            var userToToDoList = new UserToToDoList
            {
                UserId = model.UserId,
                ToDoListId = model.ToDoListId,
            };

            context.UserToToDoLists.Add(userToToDoList);
            context.SaveChanges();

            return userToToDoList;
        }

        public UserToToDoList GetUserToToDoListById(int id)
        {
            var userToToDoList = context.UserToToDoLists
                .Where(uttdl => uttdl.Id == id)
                .FirstOrDefault();

            return userToToDoList;
        }

        public UserToToDoList EditUserToToDoList(UserToToDoListModel model, int id)
        {
            var userToToDoList = GetUserToToDoListById(id);

            if (userToToDoList == null)
            {
                return userToToDoList;
            }

            userToToDoList.UserId = model.UserId;
            userToToDoList.ToDoListId = model.ToDoListId;

            context.UserToToDoLists.Update(userToToDoList);
            context.SaveChanges();

            return userToToDoList;
        }

        public UserToToDoList DeleteUserToToDoList(int id)
        {
            var userToToDoList = GetUserToToDoListById(id);

            if (userToToDoList == null)
            {
                return userToToDoList;
            }

            context.UserToToDoLists.Remove(userToToDoList);
            context.SaveChanges();

            return userToToDoList;
        }
    }
}
