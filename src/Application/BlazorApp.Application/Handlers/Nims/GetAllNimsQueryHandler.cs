using BlazorApp.Api.Queries;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class GetAllNimsQueryHandler : IQueryHandler<GetAllNimsQuery, List<Nims>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllNimsQueryHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<Nims>> HandleAsync(GetAllNimsQuery query)
        {
            // Reuse the existing method on the context
            return await _context.GetNimsRecordsAsync();
        }
    }
}


