using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class UpdateNimsCommand : ICommand
    {
        public ApplicationNims Nims { get; }
        public UpdateNimsCommand(ApplicationNims nims) => Nims = nims;
    }
}

