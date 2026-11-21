#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class FloorsService : IFloorsService
    {
        private readonly IApplicationDbContext _context;

        public FloorsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Floors> Get()
        {
            return _context.Floors.Find(FilterDefinition<Floors>.Empty).ToList();
        }

        public Floors? Get(string id)
        {
            return _context.Floors.Find(x => x._id == id).FirstOrDefault();
        }

        public Floors Create(Floors floors)
        {
            _context.Floors.InsertOne(floors);
            return floors;
        }

        public void Update(string id, Floors updatedFloors)
        {
            _context.Floors.ReplaceOne(x => x._id == id, updatedFloors);
        }

        public void Delete(Floors floorsForDeletion)
        {
            if (floorsForDeletion._id != null)
            {
                Delete(floorsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Floors.DeleteOne(x => x._id == id);
        }
    }
}

