#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IActivitysService
    {
        List<Activitys> Get();
        Activitys? Get(string id);
        Activitys Create(Activitys activitys);
        void Update(string id, Activitys updatedActivitys);
        void Delete(Activitys activitysForDeletion);
        void Delete(string id);
    }
}

