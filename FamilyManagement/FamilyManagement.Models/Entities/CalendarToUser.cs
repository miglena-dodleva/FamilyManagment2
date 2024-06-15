using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class CalendarToUser 
    {
        [Key]
        public int Id { get; set; }

        public int CalendarId { get; set; }

        [ForeignKey(nameof(CalendarId))]
        public virtual Calendar Calendar { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
