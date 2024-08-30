using AutoMapper;
using Domain.Contracts.Responses;
using Domain.Entities.SchoolStructure;

namespace Web.Mapper;

public class WebMapperProfile: Profile
{
	public WebMapperProfile()
	{
		CreateMap<School, SchoolResponse>();

		CreateMap<SchoolGround, SchoolGroundResponse>()
			.ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));

		CreateMap<SchoolClass, SchoolClassWithoutManagerResponse>()
			.ForMember(dest => dest.GroundId, opt => opt.MapFrom(src => src.Ground != null ? src.Ground.Id : Guid.Empty))
			.ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));

        CreateMap<Librarian, LibrarianResponse>()
            .ForMember(dest => dest.GroundId, opt => opt.MapFrom(src => src.Ground != null ? src.Ground.Id : Guid.Empty))
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));
    }
}
