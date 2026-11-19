using BlazorApp.Api.Commands;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

namespace BlazorApp.Api.Handlers
{
    public class DeleteNimsCommandHandler : ICommandHandler<DeleteNimsCommand>
    {
        private readonly ApplicationDbContext _context;
        public DeleteNimsCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task HandleAsync(DeleteNimsCommand command)
        {
            var filter = Builders<ApplicationNims>.Filter.Eq(n => n.Id, command.Id);
            await _context.Nims.DeleteOneAsync(filter);
        }
    }
}

