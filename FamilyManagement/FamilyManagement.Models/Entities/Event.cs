using FamilyManagement.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAFullDayEvent { get; set; }
        public ThemeColor ThemeColor { get; set; }
        public RepeatType IsRepeatEvent { get; set; }

        public int CalendarId { get; set; }
        
        [ForeignKey(nameof(CalendarId))]
        public virtual Calendar Calendar { get; set; }
    }

}
