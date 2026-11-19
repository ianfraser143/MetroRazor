#nullable enable
using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public partial class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IMongoDatabase database)
        {
            _database = database;
        }
    }
}
