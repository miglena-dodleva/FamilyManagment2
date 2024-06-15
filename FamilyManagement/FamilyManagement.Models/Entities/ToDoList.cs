using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class ToDoList 
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UserToToDoList> UserToToDoLists { get; set; }


    }
}
