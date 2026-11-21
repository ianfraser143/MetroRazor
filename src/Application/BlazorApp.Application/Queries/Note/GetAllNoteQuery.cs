using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetAllNoteQuery : IQuery<List<Notes>>
    {
        // No parameters needed for retrieving all records
    }
}

