using BlazorApp.Api.Queries;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, ApplicationNotes?>
    {
        private readonly ApplicationDbContext _context;
        public GetNoteByIdQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<ApplicationNotes?> HandleAsync(GetNoteByIdQuery query)
        {
            var filter = Builders<ApplicationNotes>.Filter.Eq(n => n.Id, query.Id);
            return await _context.Notes.Find(filter).FirstOrDefaultAsync();
        }
    }
}
