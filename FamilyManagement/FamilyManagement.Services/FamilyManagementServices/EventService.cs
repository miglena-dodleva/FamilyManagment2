using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using System.Globalization;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class EventService : IEventService
    {
        private readonly FamilyManagementDbContext context;

        public EventService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<Event> GetAllEvents()
        {
            var events = context.Events
                .ToList();

            return events;
        }

        public Event CreateEvent(EventModel model)
        {
            var newEvent = new Event
            {
                Title = model.Title,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                IsAFullDayEvent = model.IsAFullDayEvent,
                ThemeColor = model.ThemeColor,
                IsRepeatEvent = model.IsRepeatEvent,
                CalendarId = model.CalendarId
            };

            context.Events.Add(newEvent);
            context.SaveChanges();

            return newEvent;
        }

        public Event GetEventById(int eventId)
        {
            var currentEvent = context.Events
               .Where(e => e.Id == eventId)
               .FirstOrDefault();

            return currentEvent;
        }

        public Event EditEvent(EventModel model, int eventId)
        {
            var currentEvent = GetEventById(eventId);

            if (currentEvent != null)
            {
                return currentEvent;
            }

            currentEvent.Title = model.Title;
            currentEvent.Description = model.Description;
            currentEvent.StartDate = model.StartDate;
            currentEvent.EndDate = model.EndDate;
            currentEvent.StartTime = model.StartTime;
            currentEvent.EndTime = model.EndTime;
            currentEvent.IsAFullDayEvent = model.IsAFullDayEvent;
            currentEvent.ThemeColor = model.ThemeColor;
            currentEvent.IsRepeatEvent = model.IsRepeatEvent;
            currentEvent.CalendarId = model.CalendarId;

            context.Events.Update(currentEvent);
            context.SaveChanges ();

            return currentEvent;
        }

        public Event DeleteEvent(int eventId)
        {
            var currentEvent = GetEventById(eventId);

            if (currentEvent != null)
            {
                return currentEvent;
            }

            context.Events.Remove(currentEvent);
            context.SaveChanges ();

            return currentEvent;
        }
    }
}
