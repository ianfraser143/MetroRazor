#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class StatusOptionsService : IStatusOptionsService
    {
        private readonly IApplicationDbContext _context;

        public StatusOptionsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<StatusOptions> Get()
        {
            return _context.StatusOptions.Find(FilterDefinition<StatusOptions>.Empty).ToList();
        }

        public StatusOptions? Get(string id)
        {
            return _context.StatusOptions.Find(x => x._id == id).FirstOrDefault();
        }

        public StatusOptions Create(StatusOptions statusOptions)
        {
            _context.StatusOptions.InsertOne(statusOptions);
            return statusOptions;
        }

        public void Update(string id, StatusOptions updatedStatusOptions)
        {
            _context.StatusOptions.ReplaceOne(x => x._id == id, updatedStatusOptions);
        }

        public void Delete(StatusOptions statusOptionsForDeletion)
        {
            if (statusOptionsForDeletion._id != null)
            {
                Delete(statusOptionsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.StatusOptions.DeleteOne(x => x._id == id);
        }
    }
}

