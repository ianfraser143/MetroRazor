using BlazorApp.Api.Queries;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class GetAllNimsQueryHandler : IQueryHandler<GetAllNimsQuery, List<ApplicationNims>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllNimsQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<List<ApplicationNims>> HandleAsync(GetAllNimsQuery query)
        {
            // Reuse the existing method on the context
            return await _context.GetNimsRecordsAsync();
        }
    }
}

