using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface ICalendarToFamilyService
    {
        List<CalendarToFamily> GetAllCalendarToFamilies();
        
        CalendarToFamily GetCalendarToFamilyById(int id);
        
        CalendarToFamily CreateCalendarToFamily(CalendarToFamilyModel model);
        
        CalendarToFamily EditCalendarToFamily(CalendarToFamilyModel model, int id);
        
        CalendarToFamily DeleteCalendarToFamily(int id);
    }
}
