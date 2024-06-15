
using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class CalendarService : ICalendarService
    {
        private readonly FamilyManagementDbContext context;

        public CalendarService(FamilyManagementDbContext context)
        {
            this.context = context;
        }
        
        public List<Calendar> GetAllCalendars()
        {
            var calendars = context.Calendars
                 .ToList();

            return calendars;
        }

        public Calendar CreateCalendar(CalendarModel model)
        {
            var calendar = new Calendar
            {
                Name = model.Name
            };

            context.Calendars.Add(calendar);
            context.SaveChanges();

            return calendar;
        }
        
        public Calendar GetCalendarById(int calendarId)
        {
            var calendar = context.Calendars
                .Where(c => c.Id == calendarId)
                .FirstOrDefault();

            return calendar;
        }

        public Calendar EditCalendar(CalendarModel model, int calendarId)
        {
            var calendar = GetCalendarById(calendarId);

            if (calendar == null)
            {
                return calendar;
            }

            calendar.Name = model.Name;

            context.Calendars.Update(calendar);
            context.SaveChanges();

            return calendar;
        }
        

        public Calendar DeleteCalendar(int calendarId)
        {
            var calendar = GetCalendarById(calendarId);

            if (calendar == null)
            {
                return calendar;
            }

            context.Calendars.Remove(calendar);
            context.SaveChanges();

            return calendar;
        }
    }
}
