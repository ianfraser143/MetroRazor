using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateNoteCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(UpdateNoteCommand command)
        {
            var filter = Builders<Notes>.Filter.Eq(n => n.Id, command.Note.Id);
            await _context.Notes.ReplaceOneAsync(filter, command.Note);
        }
    }
}


