using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetAllNimsQuery : IQuery<List<ApplicationNims>>
    {
        // No parameters needed for retrieving all records
    }
}
