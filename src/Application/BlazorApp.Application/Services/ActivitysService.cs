#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class ActivitysService : IActivitysService
    {
        private readonly IApplicationDbContext _context;

        public ActivitysService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Activitys> Get()
        {
            return _context.Activities.Find(FilterDefinition<Activitys>.Empty).ToList();
        }

        public Activitys? Get(string id)
        {
            return _context.Activities.Find(x => x._id == id).FirstOrDefault();
        }

        public Activitys Create(Activitys activitys)
        {
            _context.Activities.InsertOne(activitys);
            return activitys;
        }

        public void Update(string id, Activitys updatedActivitys)
        {
            _context.Activities.ReplaceOne(x => x._id == id, updatedActivitys);
        }

        public void Delete(Activitys activitysForDeletion)
        {
            if (activitysForDeletion._id != null)
            {
                Delete(activitysForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Activities.DeleteOne(x => x._id == id);
        }
    }
}

