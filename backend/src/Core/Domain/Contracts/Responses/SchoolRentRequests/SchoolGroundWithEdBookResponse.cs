using Domain.Contracts.Responses.EdBooks;
using Domain.Contracts.Responses.School;

namespace Domain.Contracts.Responses.SchoolRentRequests;

public record SchoolGroundWithEdBookResponse(SchoolGroundResponse Ground, EdBookInBalanceResponse EdBook);