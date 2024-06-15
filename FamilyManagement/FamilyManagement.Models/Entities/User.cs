using FamilyManagement.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace FamilyManagement.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role FamilyRole { get; set; }
       
        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<CalendarToUser> CalendarToUsers { get; set; }
        public virtual ICollection<UserToToDoList> UserToToDoLists { get; set; }
    }
}
