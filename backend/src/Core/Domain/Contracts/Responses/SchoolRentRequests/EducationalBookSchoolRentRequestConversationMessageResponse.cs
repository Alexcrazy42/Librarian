using Domain.Enums;

namespace Domain.Contracts.Responses.SchoolRentRequests;

public class EducationalBookSchoolRentRequestConversationMessageResponse
{
    public Guid Id { get; set; }

    public Guid? GroundSenderId { get; set; }

    public string Message { get; set; }

    public SchoolRentConversationMessageStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool ViewedByReveiver { get; set; }

    public EducationalBookSchoolRentRequestResponse RentRequest { get; set; }
}