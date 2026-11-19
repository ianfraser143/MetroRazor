using BlazorApp.Api.Commands;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand>
    {
        private readonly ApplicationDbContext _context;
        public DeleteNoteCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task HandleAsync(DeleteNoteCommand command)
        {
            var filter = Builders<ApplicationNotes>.Filter.Eq(n => n.Id, command.Id);
            await _context.Notes.DeleteOneAsync(filter);
        }
    }
}

