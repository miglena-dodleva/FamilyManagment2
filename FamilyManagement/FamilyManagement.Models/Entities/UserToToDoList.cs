using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FamilyManagement.Data.Entities
{
    public class UserToToDoList
    {
        [Key]
        public int Id { get; set; }

        public int ToDoListId { get; set; }

        [ForeignKey(nameof(ToDoListId))]
        public virtual ToDoList ToDoList { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
