using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class UpdateNoteCommand : ICommand
    {
        public ApplicationNotes Note { get; }
        public UpdateNoteCommand(ApplicationNotes notes) => Note = notes;
    }
}

