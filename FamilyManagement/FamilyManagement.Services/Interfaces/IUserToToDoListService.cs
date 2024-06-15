using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IUserToToDoListService
    {
        List<UserToToDoList> GetAllUserToToDoLists();
        
        UserToToDoList GetUserToToDoListById(int id);
        
        UserToToDoList CreateUserToToDoList(UserToToDoListModel model);
        
        UserToToDoList EditUserToToDoList(UserToToDoListModel model, int id);
        
        UserToToDoList DeleteUserToToDoList(int id);
    }
}
