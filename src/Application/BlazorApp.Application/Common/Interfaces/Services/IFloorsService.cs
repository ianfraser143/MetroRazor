#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IFloorsService
    {
        List<Floors> Get();
        Floors? Get(string id);
        Floors Create(Floors floors);
        void Update(string id, Floors updatedFloors);
        void Delete(Floors floorsForDeletion);
        void Delete(string id);
    }
}

