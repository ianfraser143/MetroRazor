#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class ActivityTracksService : IActivityTracksService
    {
        private readonly IApplicationDbContext _context;

        public ActivityTracksService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<ActivityTracks> Get()
        {
            return _context.ActivityTracks.Find(FilterDefinition<ActivityTracks>.Empty).ToList();
        }

        public ActivityTracks? Get(string id)
        {
            return _context.ActivityTracks.Find(x => x._id == id).FirstOrDefault();
        }

        public ActivityTracks Create(ActivityTracks activityTracks)
        {
            _context.ActivityTracks.InsertOne(activityTracks);
            return activityTracks;
        }

        public void Update(string id, ActivityTracks updatedActivityTracks)
        {
            _context.ActivityTracks.ReplaceOne(x => x._id == id, updatedActivityTracks);
        }

        public void Delete(ActivityTracks activityTracksForDeletion)
        {
            if (activityTracksForDeletion._id != null)
            {
                Delete(activityTracksForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.ActivityTracks.DeleteOne(x => x._id == id);
        }
    }
}

