using FamilyManagement.Data.Enums;
using FamilyManagement.Services.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Models.FamilyManagement
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Must be between 1 and 100 characters", MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        public DateTime Deadline { get; set; }

        public int OwnerId { get; set; }

        public int AssigneeId { get; set; }

        public int ToDoListId { get; set; }

    }
}
