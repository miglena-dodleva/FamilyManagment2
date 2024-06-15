using System.ComponentModel.DataAnnotations;

namespace FamilyManagement.Data.Entities
{
    public class Family 
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CalendarToFamily> CalendarToFamilies { get; set; }
    }
}
