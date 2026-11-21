#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IBuildingsService
    {
        List<Buildings> Get();
        Buildings? Get(string id);
        Buildings Create(Buildings buildings);
        void Update(string id, Buildings updatedBuildings);
        void Delete(Buildings buildingsForDeletion);
        void Delete(string id);
    }
}

