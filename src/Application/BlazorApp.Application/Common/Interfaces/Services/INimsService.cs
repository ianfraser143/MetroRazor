#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface INimsService
    {
        List<Nims> Get();
        Nims? Get(string id);
        Nims Create(Nims nims);
        void Update(string id, Nims updatedNims);
        void Delete(Nims nimsForDeletion);
        void Delete(string id);
    }
}

