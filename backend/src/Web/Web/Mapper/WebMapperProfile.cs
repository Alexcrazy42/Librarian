using AutoMapper;
using Domain.Contracts.Responses.EdBooks;
using Domain.Contracts.Responses.School;
using Domain.Contracts.Responses.SchoolRentRequests;
using Domain.Entities.Books;
using Domain.Entities.RentRequests;
using Domain.Entities.SchoolStructure;

namespace Web.Mapper;

public class WebMapperProfile: Profile
{
	public WebMapperProfile()
	{
		CreateMap<School, SchoolResponse>();

		CreateMap<SchoolGround, SchoolGroundResponse>()
			.ForMember(dest => dest.SchoolId, 
                opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));

		CreateMap<SchoolClass, SchoolClassWithoutManagerResponse>()
			.ForMember(dest => dest.GroundId, 
                opt => opt.MapFrom(src => src.Ground != null ? src.Ground.Id : Guid.Empty))
			.ForMember(dest => dest.SchoolId, 
                opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));

        CreateMap<Librarian, LibrarianResponse>()
            .ForMember(dest => dest.GroundId, 
                opt => opt.MapFrom(src => src.Ground != null ? src.Ground.Id : Guid.Empty))
            .ForMember(dest => dest.SchoolId, 
                opt => opt.MapFrom(src => src.School != null ? src.School.Id : Guid.Empty));


		CreateMap<EducationalBookSchoolRentRequest, EducationalBookSchoolRentRequestResponse>()
			.ForMember(dest => dest.DebtorGroundId,
				opt => opt.MapFrom(src => src.DebtorSchoolGround != null ? src.DebtorSchoolGround.Id : Guid.Empty))
			.ForMember(dest => dest.OwnerGroundId,
				opt => opt.MapFrom(src => src.OwnerSchoolGround != null ? src.OwnerSchoolGround.Id : Guid.Empty))
			.ForMember(dest => dest.BookId,
				opt => opt.MapFrom(src => src.OwnerSchoolGround != null ? src.Book.Id : Guid.Empty))
			.ForMember(dest => dest.CreatedBy,
				opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : Guid.Empty));

		CreateMap<EducationalBookInBalance, SchoolGroundWithEdBookResponse>()
			.ConstructUsing(src => new SchoolGroundWithEdBookResponse(
				new SchoolGroundResponse(
                    src.BookOwnerGround.Id,
					src.BookOwnerGround.Name
				),
                new EdBookInBalanceResponse()
                {
                    Id = src.Id,
                    BaseEdBook = new BaseEdBookResponse()
                    {
                        Id = src.BaseEducationalBook.Id,
                        Title = src.BaseEducationalBook.Title,
                        PublishingSeries = src.BaseEducationalBook.PublishingSeries,
                        Language = src.BaseEducationalBook.Language,
                        Level = src.BaseEducationalBook.Level,
                        Appointment = src.BaseEducationalBook.Appointment,
                        Chapter = src.BaseEducationalBook.Chapter,
                        StartClass = src.BaseEducationalBook.StartClass,
                        EndClass = src.BaseEducationalBook.EndClass
                    },
                    Price = src.Price,
                    Condition = src.Condition,
                    Year = src.Year,
                    Note = src.Note,
                    InPlaceCount = src.InPlaceCount,
                    TotalCount = src.TotalCount
                }
            ));

        CreateMap<EducationalBookSchoolRentRequestConversationMessage, EducationalBookSchoolRentRequestConversationMessageResponse>()
            .ForMember(dest => dest.GroundSenderId, 
                opt => opt.MapFrom(src => src.MessageSender != null ? src.MessageSender.Id : Guid.Empty))
            .ForMember(dest => dest.RentRequest, 
                opt => opt.MapFrom(src => src.RentRequest));
    }
}
