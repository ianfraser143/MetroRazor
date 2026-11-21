using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public partial class ApplicationDbContext
    {
        // Identity collections
        public IMongoCollection<ApplicationUser> Users => _database.GetCollection<ApplicationUser>("Users");
        public IMongoCollection<ApplicationRole> Roles => _database.GetCollection<ApplicationRole>("Roles");
        public IMongoCollection<ApplicationUserRole> UserRoles => _database.GetCollection<ApplicationUserRole>("UserRoles");
        public IMongoCollection<ApplicationUserLogin> UserLogins => _database.GetCollection<ApplicationUserLogin>("UserLogins");
        public IMongoCollection<ApplicationUserPasskey> UserPasskeys => _database.GetCollection<ApplicationUserPasskey>("UserPasskeys");
        public IMongoCollection<ApplicationUserClaim> UserClaims => _database.GetCollection<ApplicationUserClaim>("UserClaims");
        public IMongoCollection<ApplicationRoleClaim> RoleClaims => _database.GetCollection<ApplicationRoleClaim>("RoleClaims");
        public IMongoCollection<ApplicationUserToken> UserTokens => _database.GetCollection<ApplicationUserToken>("UserTokens");

        // Mongo Direct collection
        public IMongoCollection<Activitys> Activities => _database.GetCollection<Activitys>("Activity");
        public IMongoCollection<ActivityTracks> ActivityTracks => _database.GetCollection<ActivityTracks>("ActivityTracks");
        public IMongoCollection<Agencys> Agencies => _database.GetCollection<Agencys>("Agency");
        public IMongoCollection<Branchs> Branchs => _database.GetCollection<Branchs>("Branch");
        public IMongoCollection<Buildings> Buildings => _database.GetCollection<Buildings>("Building");
        public IMongoCollection<BuildingTypes> BuildingTypes => _database.GetCollection<BuildingTypes>("BuildingTypes");
        public IMongoCollection<Events> Events => _database.GetCollection<Events>("Event");
        public IMongoCollection<Floors> Floors => _database.GetCollection<Floors>("Floor");
        public IMongoCollection<Notes> Notes => _database.GetCollection<Notes>("Note");
        public IMongoCollection<Respondents> Respondents => _database.GetCollection<Respondents>("Respondent");
        public IMongoCollection<Rooms> Rooms => _database.GetCollection<Rooms>("Room");
        public IMongoCollection<StatusOptions> StatusOptions => _database.GetCollection<StatusOptions>("StatusOption");
        public IMongoCollection<Suites> Suites => _database.GetCollection<Suites>("Suite");


        public IMongoCollection<Nims> Nims => _database.GetCollection<Nims>("NIMS");



    }
}

