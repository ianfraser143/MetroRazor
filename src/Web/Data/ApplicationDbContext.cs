using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<ApplicationUser> Users => _database.GetCollection<ApplicationUser>("Users");
        public IMongoCollection<ApplicationRole> Roles => _database.GetCollection<ApplicationRole>("Roles");
        public IMongoCollection<ApplicationUserRole> UserRoles => _database.GetCollection<ApplicationUserRole>("UserRoles");
        public IMongoCollection<ApplicationUserLogin> UserLogins => _database.GetCollection<ApplicationUserLogin>("UserLogins");
        public IMongoCollection<ApplicationUserClaim> UserClaims => _database.GetCollection<ApplicationUserClaim>("UserClaims");
        public IMongoCollection<ApplicationRoleClaim> RoleClaims => _database.GetCollection<ApplicationRoleClaim>("RoleClaims");
        public IMongoCollection<ApplicationUserToken> UserTokens => _database.GetCollection<ApplicationUserToken>("UserTokens");
    }

    public class ApplicationRole
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }

    public class ApplicationUserRole
    {
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }

    public class ApplicationUserLogin
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? ProviderDisplayName { get; set; }
    }

    public class ApplicationUserClaim
    {
        public string UserId { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

    public class ApplicationRoleClaim
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

    public class ApplicationUserToken
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
    }
}
