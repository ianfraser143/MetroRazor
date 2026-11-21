#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IEventsService
    {
        List<Events> Get();
        Events? Get(string id);
        Events Create(Events events);
        void Update(string id, Events updatedEvents);
        void Delete(Events eventsForDeletion);
        void Delete(string id);
    }
}

