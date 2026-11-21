using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class DeleteNoteCommand : ICommand
    {
        public string Id { get; }
        public DeleteNoteCommand(string id) => Id = id;
    }
}

