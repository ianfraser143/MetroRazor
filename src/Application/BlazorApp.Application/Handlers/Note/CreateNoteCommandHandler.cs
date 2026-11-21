using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNoteCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(CreateNoteCommand command)
        {
            // Insert the new NIMS document into the collection
            await _context.Notes.InsertOneAsync(command.Note);
        }
    }
}

