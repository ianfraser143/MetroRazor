#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IActivityTracksService
    {
        List<ActivityTracks> Get();
        ActivityTracks? Get(string id);
        ActivityTracks Create(ActivityTracks activityTracks);
        void Update(string id, ActivityTracks updatedActivityTracks);
        void Delete(ActivityTracks activityTracksForDeletion);
        void Delete(string id);
    }
}

