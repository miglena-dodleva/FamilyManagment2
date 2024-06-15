using FamilyManagement.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class Task 
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public DateTime Deadline { get; set; }
        
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }

        public int AssigneeId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        public virtual User Assignee { get; set; }

        public int ToDoListId { get; set; }

        [ForeignKey(nameof(ToDoListId))]
        public virtual ToDoList ToDoList { get; set; }
    }
}
