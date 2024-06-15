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
    public class CalendarToUserService : ICalendarToUserService
    {
        private readonly FamilyManagementDbContext context;

        public CalendarToUserService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<CalendarToUser> GetAllCalendarToUsers()
        {
            var calendarToUsers = context.CalendarToUsers
               .ToList();

            return calendarToUsers;
        }

        public CalendarToUser CreateCalendarToUser(CalendarToUserModel model)
        {
            var calendarToUser = new CalendarToUser
            {
                UserId = model.UserId,
                CalendarId = model.CalendarId,
            };

            context.CalendarToUsers.Add(calendarToUser);
            context.SaveChanges();

            return calendarToUser;
        }

        public CalendarToUser GetCalendarToUserById(int id)
        {
            var calendarToUser = context.CalendarToUsers
                .Where(ctu => ctu.Id == id)
                .FirstOrDefault();

            return calendarToUser;
        }
        public CalendarToUser EditCalendarToUser(CalendarToUserModel model, int id)
        {
            var calendarToUser = GetCalendarToUserById(id);

            if (calendarToUser == null)
            {
                return calendarToUser;
            }

            calendarToUser.UserId = model.UserId;
            calendarToUser.CalendarId = model.CalendarId;

            context.CalendarToUsers.Update(calendarToUser);
            context.SaveChanges();

            return calendarToUser;
        }

        public CalendarToUser DeleteCalendarToUser(int id)
        {
            var calendarToUser = GetCalendarToUserById(id);

            if (calendarToUser == null)
            {
                return calendarToUser;
            }

            context.CalendarToUsers.Remove(calendarToUser);
            context.SaveChanges();

            return calendarToUser;
        }
    }
}
