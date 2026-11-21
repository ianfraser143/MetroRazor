#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IBuildingTypesService
    {
        List<BuildingTypes> Get();
        BuildingTypes? Get(string id);
        BuildingTypes Create(BuildingTypes buildingTypes);
        void Update(string id, BuildingTypes updatedBuildingTypes);
        void Delete(BuildingTypes buildingTypesForDeletion);
        void Delete(string id);
    }
}

