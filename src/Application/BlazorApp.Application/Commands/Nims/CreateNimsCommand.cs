using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class CreateNimsCommand : ICommand
    {
        public Nims Nims { get; }
        public CreateNimsCommand(Nims nims) => Nims = nims;
    }
}


