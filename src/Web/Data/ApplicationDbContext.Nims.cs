#nullable enable
using BlazorApp.Web.Data.Models.Common;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public partial class ApplicationDbContext
    {
        public async Task<List<ApplicationNims>> GetNimsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Nims.Find(FilterDefinition<ApplicationNims>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationActivitys>> GetActivityRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Activities.Find(FilterDefinition<ApplicationActivitys>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationActivityTracks>> GetActivityTracksRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await ActivityTracks.Find(FilterDefinition<ApplicationActivityTracks>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationAgencys>> GetAgencysRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Agencies.Find(FilterDefinition<ApplicationAgencys>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationBranchs>> GetBranchsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Branchs.Find(FilterDefinition<ApplicationBranchs>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationBuildings>> GetBuildingsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Buildings.Find(FilterDefinition<ApplicationBuildings>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationBuildingTypes>> GetBuildingTypesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await BuildingTypes.Find(FilterDefinition<ApplicationBuildingTypes>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationEvents>> GetEventsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Events.Find(FilterDefinition<ApplicationEvents>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationFloors>> GetFloorsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Floors.Find(FilterDefinition<ApplicationFloors>.Empty).ToListAsync(cancellationToken);
        }


        public async Task<List<ApplicationNotes>> GetNotesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Notes.Find(FilterDefinition<ApplicationNotes>.Empty).ToListAsync(cancellationToken);
        }


        public async Task<List<ApplicationRespondents>> GetRespondentsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Respondents.Find(FilterDefinition<ApplicationRespondents>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationRooms>> GetRoomsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Rooms.Find(FilterDefinition<ApplicationRooms>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationStatusOptions>> GetStatusOptionsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await StatusOptions.Find(FilterDefinition<ApplicationStatusOptions>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationSuites>> GetSuitesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Suites.Find(FilterDefinition<ApplicationSuites>.Empty).ToListAsync(cancellationToken);
        }
    





    


















        public static ApplicationNims CreateSampleNims()
        {
            return new ApplicationNims
            {
                _id = "4d0d4c238b4901a698857538",
                IsActive = true,
                CreateDate = DateTime.Parse("2023-02-18T03:09:07.000Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                ModifiedDate = DateTime.Parse("2023-02-18T03:09:07.000Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Code = "1151",
                Description = "Escort",
                Priority = "5",
                Col0 = null,
                NIMSCategorys = new Nimscategorys
                {
                    _id = "6674b614133de934fd16bda0",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                },
                NIMSTypes = new Nimstypes
                {
                    _id = "6674b614133de934fd16bd9e",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                },
                Branchs = new ApplicationBranchs
                {
                    _id = "6674b614133de934fd16bd9f",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                }
            };
        }
    }
}
