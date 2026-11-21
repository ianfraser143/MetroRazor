#nullable enable
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public partial class ApplicationDbContext
    {
        public async Task<List<Nims>> GetNimsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Nims.Find(FilterDefinition<Nims>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Activitys>> GetActivityRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Activities.Find(FilterDefinition<Activitys>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<ActivityTracks>> GetActivityTracksRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await ActivityTracks.Find(FilterDefinition<ActivityTracks>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Agencys>> GetAgencysRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Agencies.Find(FilterDefinition<Agencys>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Branchs>> GetBranchsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Branchs.Find(FilterDefinition<Branchs>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Buildings>> GetBuildingsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Buildings.Find(FilterDefinition<Buildings>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<BuildingTypes>> GetBuildingTypesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await BuildingTypes.Find(FilterDefinition<BuildingTypes>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Events>> GetEventsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Events.Find(FilterDefinition<Events>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Floors>> GetFloorsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Floors.Find(FilterDefinition<Floors>.Empty).ToListAsync(cancellationToken);
        }


        public async Task<List<Notes>> GetNotesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Notes.Find(FilterDefinition<Notes>.Empty).ToListAsync(cancellationToken);
        }


        public async Task<List<Respondents>> GetRespondentsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Respondents.Find(FilterDefinition<Respondents>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Rooms>> GetRoomsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Rooms.Find(FilterDefinition<Rooms>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<StatusOptions>> GetStatusOptionsRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await StatusOptions.Find(FilterDefinition<StatusOptions>.Empty).ToListAsync(cancellationToken);
        }
        public async Task<List<Suites>> GetSuitesRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await Suites.Find(FilterDefinition<Suites>.Empty).ToListAsync(cancellationToken);
        }

























        public static Nims CreateSampleNims()
        {
            return new Nims
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
                Branchs = new Branchs
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

