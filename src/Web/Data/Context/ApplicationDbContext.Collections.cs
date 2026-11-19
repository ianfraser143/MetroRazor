using BlazorApp.Web.Data.Models;
using BlazorApp.Web.Data.Models;
using BlazorApp.Web.Data.Models;
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
        public IMongoCollection<ApplicationActivitys> Activities => _database.GetCollection<ApplicationActivitys>("Activity");
        public IMongoCollection<ApplicationActivityTracks> ActivityTracks => _database.GetCollection<ApplicationActivityTracks>("ActivityTracks");
        public IMongoCollection<ApplicationAgencys> Agencies => _database.GetCollection<ApplicationAgencys>("Agency");
        public IMongoCollection<ApplicationBranchs> Branchs => _database.GetCollection<ApplicationBranchs>("Branch");
        public IMongoCollection<ApplicationBuildings> Buildings => _database.GetCollection<ApplicationBuildings>("Building");
        public IMongoCollection<ApplicationBuildingTypes> BuildingTypes => _database.GetCollection<ApplicationBuildingTypes>("BuildingTypes");
        public IMongoCollection<ApplicationEvents> Events => _database.GetCollection<ApplicationEvents>("Event");
        public IMongoCollection<ApplicationFloors> Floors => _database.GetCollection<ApplicationFloors>("Floor");
        public IMongoCollection<ApplicationNotes> Notes => _database.GetCollection<ApplicationNotes>("Note");
        public IMongoCollection<ApplicationRespondents> Respondents => _database.GetCollection<ApplicationRespondents>("Respondent");
        public IMongoCollection<ApplicationRooms> Rooms => _database.GetCollection<ApplicationRooms>("Room");
        public IMongoCollection<ApplicationStatusOptions> StatusOptions => _database.GetCollection<ApplicationStatusOptions>("StatusOption");
        public IMongoCollection<ApplicationSuites> Suites => _database.GetCollection<ApplicationSuites>("Suite");


        public IMongoCollection<ApplicationNims> Nims => _database.GetCollection<ApplicationNims>("NIMS");



    }
}
