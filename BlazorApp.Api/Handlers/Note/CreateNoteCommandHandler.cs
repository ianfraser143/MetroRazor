using BlazorApp.Api.Commands;
using BlazorApp.Web.Data;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand>
    {
        private readonly ApplicationDbContext _context;
        public CreateNoteCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task HandleAsync(CreateNoteCommand command)
        {
            // Insert the new NIMS document into the collection
            await _context.Notes.InsertOneAsync(command.Note);
        }
    }
}

