using BlazorApp.Api.Commands;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand>
    {
        private readonly ApplicationDbContext _context;
        public UpdateNoteCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task HandleAsync(UpdateNoteCommand command)
        {
            var filter = Builders<ApplicationNotes>.Filter.Eq(n => n.Id, command.Note.Id);
            await _context.Notes.ReplaceOneAsync(filter, command.Note);
        }
    }
}

