#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class BuildingTypesService : IBuildingTypesService
    {
        private readonly IApplicationDbContext _context;

        public BuildingTypesService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<BuildingTypes> Get()
        {
            return _context.BuildingTypes.Find(FilterDefinition<BuildingTypes>.Empty).ToList();
        }

        public BuildingTypes? Get(string id)
        {
            return _context.BuildingTypes.Find(x => x._id == id).FirstOrDefault();
        }

        public BuildingTypes Create(BuildingTypes buildingTypes)
        {
            _context.BuildingTypes.InsertOne(buildingTypes);
            return buildingTypes;
        }

        public void Update(string id, BuildingTypes updatedBuildingTypes)
        {
            _context.BuildingTypes.ReplaceOne(x => x._id == id, updatedBuildingTypes);
        }

        public void Delete(BuildingTypes buildingTypesForDeletion)
        {
            if (buildingTypesForDeletion._id != null)
            {
                Delete(buildingTypesForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.BuildingTypes.DeleteOne(x => x._id == id);
        }
    }
}

