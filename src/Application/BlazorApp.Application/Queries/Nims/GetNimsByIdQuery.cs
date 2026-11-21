using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetNimsByIdQuery : IQuery<Nims?>
    {
        public string Id { get; }
        public GetNimsByIdQuery(string id) => Id = id;
    }
}


