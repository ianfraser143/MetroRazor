#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly IApplicationDbContext _context;

        public RoomsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rooms> Get()
        {
            return _context.Rooms.Find(FilterDefinition<Rooms>.Empty).ToList();
        }

        public Rooms? Get(string id)
        {
            return _context.Rooms.Find(x => x._id == id).FirstOrDefault();
        }

        public Rooms Create(Rooms rooms)
        {
            _context.Rooms.InsertOne(rooms);
            return rooms;
        }

        public void Update(string id, Rooms updatedRooms)
        {
            _context.Rooms.ReplaceOne(x => x._id == id, updatedRooms);
        }

        public void Delete(Rooms roomsForDeletion)
        {
            if (roomsForDeletion._id != null)
            {
                Delete(roomsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Rooms.DeleteOne(x => x._id == id);
        }
    }
}

