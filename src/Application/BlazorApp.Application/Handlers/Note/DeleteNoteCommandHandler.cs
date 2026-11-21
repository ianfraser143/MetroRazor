using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteNoteCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(DeleteNoteCommand command)
        {
            var filter = Builders<Notes>.Filter.Eq(n => n.Id, command.Id);
            await _context.Notes.DeleteOneAsync(filter);
        }
    }
}


