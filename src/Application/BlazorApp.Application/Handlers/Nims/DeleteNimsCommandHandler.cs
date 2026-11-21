using BlazorApp.Api.Commands;
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class DeleteNimsCommandHandler : ICommandHandler<DeleteNimsCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteNimsCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task HandleAsync(DeleteNimsCommand command)
        {
            var filter = Builders<Nims>.Filter.Eq(n => n.Id, command.Id);
            await _context.Nims.DeleteOneAsync(filter);
        }
    }
}


