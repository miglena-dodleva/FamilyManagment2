using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class ToDoListService : IToDoListService
    {
        private readonly FamilyManagementDbContext context;

        public ToDoListService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<ToDoList> GetAllToDoLists()
        {
            var toDoLists = context.ToDoLists
                .ToList();

            return toDoLists;
        }

        public ToDoList CreateToDoList(ToDoListModel model)
        {
            var toDoList = new ToDoList
            {
                Name = model.Name
            };

            context.ToDoLists.Add(toDoList);
            context.SaveChanges();

            return toDoList;
        }
        
        public ToDoList GetToDoListById(int toDoListId)
        {
            var toDoList = context.ToDoLists
                .Where(t => t.Id == toDoListId)
                .FirstOrDefault();

            return toDoList;
        }

        public ToDoList EditToDoList(ToDoListModel model, int toDoListId)
        {
            var toDoList = GetToDoListById(toDoListId);

            if (toDoList == null)
            {
                return toDoList;
            }

            toDoList.Name = model.Name;

            context.ToDoLists.Update(toDoList);
            context.SaveChanges();

            return toDoList;
        }

        public ToDoList DeleteToDoList(int toDoListId)
        {
            var toDoList = GetToDoListById(toDoListId);

            if (toDoList == null)
            {
                return toDoList;
            }

            context.ToDoLists.Remove(toDoList);
            context.SaveChanges();

            return toDoList;
        }
    }
}
