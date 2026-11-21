#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class AgencysService : IAgencysService
    {
        private readonly IApplicationDbContext _context;

        public AgencysService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Agencys> Get()
        {
            return _context.Agencies.Find(FilterDefinition<Agencys>.Empty).ToList();
        }

        public Agencys? Get(string id)
        {
            return _context.Agencies.Find(x => x._id == id).FirstOrDefault();
        }

        public Agencys Create(Agencys agencys)
        {
            _context.Agencies.InsertOne(agencys);
            return agencys;
        }

        public void Update(string id, Agencys updatedAgencys)
        {
            _context.Agencies.ReplaceOne(x => x._id == id, updatedAgencys);
        }

        public void Delete(Agencys agencysForDeletion)
        {
            if (agencysForDeletion._id != null)
            {
                Delete(agencysForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Agencies.DeleteOne(x => x._id == id);
        }
    }
}

