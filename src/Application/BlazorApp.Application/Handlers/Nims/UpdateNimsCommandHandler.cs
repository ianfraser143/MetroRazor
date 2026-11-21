using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class UpdateNimsCommandHandler : ICommandHandler<UpdateNimsCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateNimsCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(UpdateNimsCommand command)
        {
            var filter = Builders<Nims>.Filter.Eq(n => n.Id, command.Nims.Id);
            await _context.Nims.ReplaceOneAsync(filter, command.Nims);
        }
    }
}


