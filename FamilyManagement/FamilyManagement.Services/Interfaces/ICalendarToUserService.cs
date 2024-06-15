using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface ICalendarToUserService
    {
        List<CalendarToUser> GetAllCalendarToUsers();
        
        CalendarToUser GetCalendarToUserById(int id);
        
        CalendarToUser CreateCalendarToUser(CalendarToUserModel model);
        
        CalendarToUser EditCalendarToUser(CalendarToUserModel model, int id);
        
        CalendarToUser DeleteCalendarToUser(int id);
    }
}
