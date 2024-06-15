using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IToDoListService
    {
        List<ToDoList> GetAllToDoLists();

        ToDoList GetToDoListById(int toDoListId);

        ToDoList CreateToDoList(ToDoListModel model);

        ToDoList EditToDoList(ToDoListModel model, int toDoListId);

        ToDoList DeleteToDoList(int toDoListId);
    }
}
