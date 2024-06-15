using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface ICalendarService
    {
        List<Calendar> GetAllCalendars();

        Calendar GetCalendarById(int calendarId);

        Calendar CreateCalendar(CalendarModel model);

        Calendar EditCalendar(CalendarModel model, int calendarId);

        Calendar DeleteCalendar(int calendarId);
    }
}
