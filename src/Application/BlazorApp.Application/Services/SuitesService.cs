#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class SuitesService : ISuitesService
    {
        private readonly IApplicationDbContext _context;

        public SuitesService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Suites> Get()
        {
            return _context.Suites.Find(FilterDefinition<Suites>.Empty).ToList();
        }

        public Suites? Get(string id)
        {
            return _context.Suites.Find(x => x._id == id).FirstOrDefault();
        }

        public Suites Create(Suites suites)
        {
            _context.Suites.InsertOne(suites);
            return suites;
        }

        public void Update(string id, Suites updatedSuites)
        {
            _context.Suites.ReplaceOne(x => x._id == id, updatedSuites);
        }

        public void Delete(Suites suitesForDeletion)
        {
            if (suitesForDeletion._id != null)
            {
                Delete(suitesForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Suites.DeleteOne(x => x._id == id);
        }
    }
}

