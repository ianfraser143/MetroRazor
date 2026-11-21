#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IRespondentsService
    {
        List<Respondents> Get();
        Respondents? Get(string id);
        Respondents Create(Respondents respondents);
        void Update(string id, Respondents updatedRespondents);
        void Delete(Respondents respondentsForDeletion);
        void Delete(string id);
    }
}

