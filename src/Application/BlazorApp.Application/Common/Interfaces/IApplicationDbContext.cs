using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        // Identity collections
        IMongoCollection<ApplicationUser> Users { get; }
        IMongoCollection<ApplicationRole> Roles { get; }
        IMongoCollection<ApplicationUserRole> UserRoles { get; }
        IMongoCollection<ApplicationUserLogin> UserLogins { get; }
        IMongoCollection<ApplicationUserPasskey> UserPasskeys { get; }
        IMongoCollection<ApplicationUserClaim> UserClaims { get; }
        IMongoCollection<ApplicationRoleClaim> RoleClaims { get; }
        IMongoCollection<ApplicationUserToken> UserTokens { get; }

        // Mongo Direct collection
        IMongoCollection<Activitys> Activities { get; }
        IMongoCollection<ActivityTracks> ActivityTracks { get; }
        IMongoCollection<Agencys> Agencies { get; }
        IMongoCollection<Branchs> Branchs { get; }
        IMongoCollection<Buildings> Buildings { get; }
        IMongoCollection<BuildingTypes> BuildingTypes { get; }
        IMongoCollection<Events> Events { get; }
        IMongoCollection<Floors> Floors { get; }
        IMongoCollection<Notes> Notes { get; }
        IMongoCollection<Respondents> Respondents { get; }
        IMongoCollection<Rooms> Rooms { get; }
        IMongoCollection<StatusOptions> StatusOptions { get; }
        IMongoCollection<Suites> Suites { get; }
        IMongoCollection<Nims> Nims { get; }

        Task<List<Nims>> GetNimsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Activitys>> GetActivityRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<ActivityTracks>> GetActivityTracksRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Agencys>> GetAgencysRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Branchs>> GetBranchsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Buildings>> GetBuildingsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<BuildingTypes>> GetBuildingTypesRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Events>> GetEventsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Floors>> GetFloorsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Notes>> GetNotesRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Respondents>> GetRespondentsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Rooms>> GetRoomsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<StatusOptions>> GetStatusOptionsRecordsAsync(CancellationToken cancellationToken = default);
        Task<List<Suites>> GetSuitesRecordsAsync(CancellationToken cancellationToken = default);
    }
}
