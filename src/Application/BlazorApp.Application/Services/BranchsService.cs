#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class BranchsService : IBranchsService
    {
        private readonly IApplicationDbContext _context;

        public BranchsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Branchs> Get()
        {
            return _context.Branchs.Find(FilterDefinition<Branchs>.Empty).ToList();
        }

        public Branchs? Get(string id)
        {
            return _context.Branchs.Find(x => x._id == id).FirstOrDefault();
        }

        public Branchs Create(Branchs branchs)
        {
            _context.Branchs.InsertOne(branchs);
            return branchs;
        }

        public void Update(string id, Branchs updatedBranchs)
        {
            _context.Branchs.ReplaceOne(x => x._id == id, updatedBranchs);
        }

        public void Delete(Branchs branchsForDeletion)
        {
            if (branchsForDeletion._id != null)
            {
                Delete(branchsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Branchs.DeleteOne(x => x._id == id);
        }
    }
}

