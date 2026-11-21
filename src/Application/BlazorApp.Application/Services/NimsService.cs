#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class NimsService : INimsService
    {
        private readonly IApplicationDbContext _context;

        public NimsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Nims> Get()
        {
            return _context.Nims.Find(FilterDefinition<Nims>.Empty).ToList();
        }

        public Nims? Get(string id)
        {
            return _context.Nims.Find(x => x._id == id).FirstOrDefault();
        }

        public Nims Create(Nims nims)
        {
            _context.Nims.InsertOne(nims);
            return nims;
        }

        public void Update(string id, Nims updatedNims)
        {
            _context.Nims.ReplaceOne(x => x._id == id, updatedNims);
        }

        public void Delete(Nims nimsForDeletion)
        {
            if (nimsForDeletion._id != null)
            {
                Delete(nimsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Nims.DeleteOne(x => x._id == id);
        }
    }
}

