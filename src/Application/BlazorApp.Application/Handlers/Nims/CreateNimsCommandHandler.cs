using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using LiteBus;

namespace BlazorApp.Api.Handlers
{
    public class CreateNimsCommandHandler : ICommandHandler<CreateNimsCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNimsCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(CreateNimsCommand command)
        {
            // Insert the new NIMS document into the collection
            await _context.Nims.InsertOneAsync(command.Nims);
        }
    }
}

