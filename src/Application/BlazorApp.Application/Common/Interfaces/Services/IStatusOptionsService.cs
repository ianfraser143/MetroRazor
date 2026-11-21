#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IStatusOptionsService
    {
        List<StatusOptions> Get();
        StatusOptions? Get(string id);
        StatusOptions Create(StatusOptions statusOptions);
        void Update(string id, StatusOptions updatedStatusOptions);
        void Delete(StatusOptions statusOptionsForDeletion);
        void Delete(string id);
    }
}

