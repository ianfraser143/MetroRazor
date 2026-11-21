#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface ISuitesService
    {
        List<Suites> Get();
        Suites? Get(string id);
        Suites Create(Suites suites);
        void Update(string id, Suites updatedSuites);
        void Delete(Suites suitesForDeletion);
        void Delete(string id);
    }
}

