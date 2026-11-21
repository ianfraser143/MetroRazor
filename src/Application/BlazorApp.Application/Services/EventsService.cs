#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class EventsService : IEventsService
    {
        private readonly IApplicationDbContext _context;

        public EventsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Events> Get()
        {
            return _context.Events.Find(FilterDefinition<Events>.Empty).ToList();
        }

        public Events? Get(string id)
        {
            return _context.Events.Find(x => x._id == id).FirstOrDefault();
        }

        public Events Create(Events events)
        {
            _context.Events.InsertOne(events);
            return events;
        }

        public void Update(string id, Events updatedEvents)
        {
            _context.Events.ReplaceOne(x => x._id == id, updatedEvents);
        }

        public void Delete(Events eventsForDeletion)
        {
            if (eventsForDeletion._id != null)
            {
                Delete(eventsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Events.DeleteOne(x => x._id == id);
        }
    }
}

