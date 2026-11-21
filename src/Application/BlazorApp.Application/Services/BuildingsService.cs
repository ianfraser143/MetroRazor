#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly IApplicationDbContext _context;

        public BuildingsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Buildings> Get()
        {
            return _context.Buildings.Find(FilterDefinition<Buildings>.Empty).ToList();
        }

        public Buildings? Get(string id)
        {
            return _context.Buildings.Find(x => x._id == id).FirstOrDefault();
        }

        public Buildings Create(Buildings buildings)
        {
            _context.Buildings.InsertOne(buildings);
            return buildings;
        }

        public void Update(string id, Buildings updatedBuildings)
        {
            _context.Buildings.ReplaceOne(x => x._id == id, updatedBuildings);
        }

        public void Delete(Buildings buildingsForDeletion)
        {
            if (buildingsForDeletion._id != null)
            {
                Delete(buildingsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Buildings.DeleteOne(x => x._id == id);
        }
    }
}

