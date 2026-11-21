#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface IBranchsService
    {
        List<Branchs> Get();
        Branchs? Get(string id);
        Branchs Create(Branchs branchs);
        void Update(string id, Branchs updatedBranchs);
        void Delete(Branchs branchsForDeletion);
        void Delete(string id);
    }
}

