using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class CalendarToFamily
    {
        [Key]
        public int Id { get; set; }

        public int CalendarId { get; set; }

        [ForeignKey(nameof(CalendarId))]
        public virtual Calendar Calendar { get; set; }

        public int FamilyId { get; set; }

        [ForeignKey(nameof(FamilyId))]
        public virtual Family Family { get; set; }
    }
}
