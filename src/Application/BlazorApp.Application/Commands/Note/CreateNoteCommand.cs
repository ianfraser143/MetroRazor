using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class CreateNoteCommand : ICommand
    {
        public Notes Note { get; }
        public CreateNoteCommand(Notes notes) => Note = notes;
    }
}


