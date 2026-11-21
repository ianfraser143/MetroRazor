#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IRoomsService
    {
        List<Rooms> Get();
        Rooms? Get(string id);
        Rooms Create(Rooms rooms);
        void Update(string id, Rooms updatedRooms);
        void Delete(Rooms roomsForDeletion);
        void Delete(string id);
    }
}

