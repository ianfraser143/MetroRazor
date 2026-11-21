#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IAgencysService
    {
        List<Agencys> Get();
        Agencys? Get(string id);
        Agencys Create(Agencys agencys);
        void Update(string id, Agencys updatedAgencys);
        void Delete(Agencys agencysForDeletion);
        void Delete(string id);
    }
}

