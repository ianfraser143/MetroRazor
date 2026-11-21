using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class UpdateNoteCommand : ICommand
    {
        public Notes Note { get; }
        public UpdateNoteCommand(Notes notes) => Note = notes;
    }
}


