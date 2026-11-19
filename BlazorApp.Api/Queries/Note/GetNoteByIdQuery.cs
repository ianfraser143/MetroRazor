using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetNoteByIdQuery : IQuery<ApplicationNotes?>
    {
        public string Id { get; }
        public GetNoteByIdQuery(string id) => Id = id;
    }
}

