using Mapster;
using BlazorApp.Api.Models;
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Api.MappingProfiles
{
    public class NoteMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map from domain model to DTO
            config.NewConfig<ApplicationNotes, NoteDto>()
                .Map(dst => dst.Id, src => src._id);

            // Map from DTO to domain model (for create/update)
            config.NewConfig<NoteDto, ApplicationNotes>()
                .Map(dst => dst._id, src => src.Id);
        }
    }
}

