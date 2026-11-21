using BlazorApp.Api.Queries;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class GetAllNoteQueryHandler : IQueryHandler<GetAllNoteQuery, List<Notes>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllNoteQueryHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<Notes>> HandleAsync(GetAllNoteQuery query)
        {
            // Reuse the existing method on the context
            return await _context.GetNotesRecordsAsync();
        }
    }
}


