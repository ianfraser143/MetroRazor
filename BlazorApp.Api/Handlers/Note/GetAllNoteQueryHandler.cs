using BlazorApp.Api.Queries;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class GetAllNoteQueryHandler : IQueryHandler<GetAllNoteQuery, List<ApplicationNotes>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllNoteQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<List<ApplicationNotes>> HandleAsync(GetAllNoteQuery query)
        {
            // Reuse the existing method on the context
            return await _context.GetNotesRecordsAsync();
        }
    }
}

