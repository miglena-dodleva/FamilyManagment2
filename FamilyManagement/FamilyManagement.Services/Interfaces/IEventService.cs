using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;

namespace FamilyManagement.Services.Interfaces
{
    public interface IEventService
    {
        List<Event> GetAllEvents();

        Event GetEventById(int eventId);

        Event CreateEvent(EventModel model);

        Event EditEvent(EventModel model, int eventId);

        Event DeleteEvent(int eventId);
    }
}
