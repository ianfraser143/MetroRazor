using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Queries
{
    public class GetNimsByIdQuery : IQuery<ApplicationNims?>
    {
        public string Id { get; }
        public GetNimsByIdQuery(string id) => Id = id;
    }
}

