using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class CreateNoteCommand : ICommand
    {
        public ApplicationNotes Note { get; }
        public CreateNoteCommand(ApplicationNotes notes) => Note = notes;
    }
}

