using BlazorApp.Api.Models;
using BlazorApp.Web.Data.Models;
using Mapster;

namespace BlazorApp.Api.MappingProfiles
{
    public class NimsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map from domain model to DTO
            config.NewConfig<Nims, NimsDto>()
                .Map(dst => dst.Id, src => src._id)
                .Map(dst => dst.CategoryId, src => src.NIMSCategorys != null ? src.NIMSCategorys._id : null)
                .Map(dst => dst.TypeId, src => src.NIMSTypes != null ? src.NIMSTypes._id : null)
                .Map(dst => dst.BranchId, src => src.Branchs != null ? src.Branchs._id : null);

            // Map from DTO to domain model (for create/update)
            config.NewConfig<NimsDto, Nims>()
                .Map(dst => dst._id, src => src.Id)
                .Ignore(dst => dst.NIMSCategorys!)
                .Ignore(dst => dst.NIMSTypes!)
                .Ignore(dst => dst.Branchs!);
        }
    }
}

