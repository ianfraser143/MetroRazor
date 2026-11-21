using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetAllNimsQuery : IQuery<List<Nims>>
    {
        // No parameters needed for retrieving all records
    }
}

