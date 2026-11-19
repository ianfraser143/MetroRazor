using BlazorApp.Api.Commands;
using BlazorApp.Web.Data;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class CreateNimsCommandHandler : ICommandHandler<CreateNimsCommand>
    {
        private readonly ApplicationDbContext _context;
        public CreateNimsCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task HandleAsync(CreateNimsCommand command)
        {
            // Insert the new NIMS document into the collection
            await _context.Nims.InsertOneAsync(command.Nims);
        }
    }
}

