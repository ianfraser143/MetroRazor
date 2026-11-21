using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class UpdateNimsCommand : ICommand
    {
        public Nims Nims { get; }
        public UpdateNimsCommand(Nims nims) => Nims = nims;
    }
}


