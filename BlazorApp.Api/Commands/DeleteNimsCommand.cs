using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class DeleteNimsCommand : ICommand
    {
        public string Id { get; }
        public DeleteNimsCommand(string id) => Id = id;
    }
}

