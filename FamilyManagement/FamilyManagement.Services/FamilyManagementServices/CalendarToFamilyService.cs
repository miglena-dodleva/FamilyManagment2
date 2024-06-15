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
    public class CalendarToFamilyService : ICalendarToFamilyService
    {
        private readonly FamilyManagementDbContext context;

        public CalendarToFamilyService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<CalendarToFamily> GetAllCalendarToFamilies()
        {
            var calendarToFamilies = context.CalendarToFamilies
                .ToList();

            return calendarToFamilies;
        }

        public CalendarToFamily CreateCalendarToFamily(CalendarToFamilyModel model)
        {
            var calendarToFamily = new CalendarToFamily
            {
                FamilyId = model.FamilyId,
                CalendarId = model.CalendarId,
            };

            context.CalendarToFamilies.Add(calendarToFamily);
            context.SaveChanges();

            return calendarToFamily;
        }

        public CalendarToFamily GetCalendarToFamilyById(int id)
        {
            var calendarToFamily = context.CalendarToFamilies
                .Where(ctf => ctf.Id == id)
                .FirstOrDefault();

            return calendarToFamily;
        }
        public CalendarToFamily EditCalendarToFamily(CalendarToFamilyModel model, int id)
        {
            var calendarToFamily = GetCalendarToFamilyById(id);

            if (calendarToFamily == null)
            {
                return calendarToFamily;
            }

            calendarToFamily.FamilyId = model.FamilyId;
            calendarToFamily.CalendarId = model.CalendarId;

            context.CalendarToFamilies.Update(calendarToFamily);
            context.SaveChanges();

            return calendarToFamily;
        }

        public CalendarToFamily DeleteCalendarToFamily(int id)
        {
            var calendarToFamily = GetCalendarToFamilyById(id);

            if (calendarToFamily == null)
            {
                return calendarToFamily;
            }

            context.CalendarToFamilies.Remove(calendarToFamily);
            context.SaveChanges();

            return calendarToFamily;
        }

    }
}
