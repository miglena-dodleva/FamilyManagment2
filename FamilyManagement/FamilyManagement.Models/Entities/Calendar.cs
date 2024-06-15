using System.ComponentModel.DataAnnotations;

namespace FamilyManagement.Data.Entities
{
    public class Calendar 
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CalendarToUser> CalendarToUsers { get; set; }
        public virtual ICollection<CalendarToFamily> CalendarToFamilies { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
