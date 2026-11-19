using BlazorApp.Api.Queries;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class GetNimsByIdQueryHandler : IQueryHandler<GetNimsByIdQuery, ApplicationNims?>
    {
        private readonly ApplicationDbContext _context;
        public GetNimsByIdQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<ApplicationNims?> HandleAsync(GetNimsByIdQuery query)
        {
            var filter = Builders<ApplicationNims>.Filter.Eq(n => n.Id, query.Id);
            return await _context.Nims.Find(filter).FirstOrDefaultAsync();
        }
    }
}
