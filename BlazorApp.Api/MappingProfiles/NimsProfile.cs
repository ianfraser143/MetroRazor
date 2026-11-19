using AutoMapper;
using BlazorApp.Api.Models;
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Api.MappingProfiles
{
    public class NimsProfile : Profile
    {
        public NimsProfile()
        {
            // Map from domain model to DTO
            CreateMap<ApplicationNims, NimsDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src._id))
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.NIMSCategorys != null ? src.NIMSCategorys._id : null))
                .ForMember(dst => dst.TypeId, opt => opt.MapFrom(src => src.NIMSTypes != null ? src.NIMSTypes._id : null))
                .ForMember(dst => dst.BranchId, opt => opt.MapFrom(src => src.Branchs != null ? src.Branchs._id : null));

            // Map from DTO to domain model (for create/update)
            CreateMap<NimsDto, ApplicationNims>()
                .ForMember(dst => dst._id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.NIMSCategorys, opt => opt.Ignore()) // handled elsewhere if needed
                .ForMember(dst => dst.NIMSTypes, opt => opt.Ignore())
                .ForMember(dst => dst.Branchs, opt => opt.Ignore());
        }
    }
}

