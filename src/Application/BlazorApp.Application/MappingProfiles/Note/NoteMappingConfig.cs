using BlazorApp.Api.Models;
using BlazorApp.Web.Data.Models;
using Mapster;

namespace BlazorApp.Api.MappingProfiles
{
    public class NoteMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map from domain model to DTO
            config.NewConfig<Notes, NoteDto>()
                .Map(dst => dst.Id, src => src._id);

            // Map from DTO to domain model (for create/update)
            config.NewConfig<NoteDto, Notes>()
                .Map(dst => dst._id, src => src.Id);
        }
    }
}


