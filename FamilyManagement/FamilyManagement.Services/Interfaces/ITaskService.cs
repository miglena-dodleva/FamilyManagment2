using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface ITaskService
    {
        List<Data.Entities.Task> GetAllTasks();

        Data.Entities.Task GetTaskById(int taskId);

        Data.Entities.Task CreateTask(TaskModel model);

        Data.Entities.Task EditTask(TaskModel model, int taskId);

        Data.Entities.Task DeleteTask(int taskId);
    }
}
