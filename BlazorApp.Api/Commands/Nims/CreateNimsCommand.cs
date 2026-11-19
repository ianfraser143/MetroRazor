using BlazorApp.Web.Data.Models;
using LiteBus;

namespace BlazorApp.Api.Commands
{
    public class CreateNimsCommand : ICommand
    {
        public ApplicationNims Nims { get; }
        public CreateNimsCommand(ApplicationNims nims) => Nims = nims;
    }
}

