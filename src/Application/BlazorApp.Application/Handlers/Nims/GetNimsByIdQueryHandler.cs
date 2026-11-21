using BlazorApp.Api.Queries;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class GetNimsByIdQueryHandler : IQueryHandler<GetNimsByIdQuery, Nims?>
    {
        private readonly IApplicationDbContext _context;
        public GetNimsByIdQueryHandler(IApplicationDbContext context) => _context = context;

        public async Task<Nims?> HandleAsync(GetNimsByIdQuery query)
        {
            var filter = Builders<Nims>.Filter.Eq(n => n.Id, query.Id);
            return await _context.Nims.Find(filter).FirstOrDefaultAsync();
        }
    }
}

