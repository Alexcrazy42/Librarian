using Domain.Entities.SchoolStructure;
using Domain.Enums;

namespace Domain.Entities.RentRequests;

/// <summary>
/// Сообщения прикрепленные к определенному запросу 
/// книги учебной литературы
/// </summary>
public class EducationalBookSchoolRentRequestConversationMessage
{
    public const int MessageMaxLength = 200;

    public Guid Id { get; private set; }

    public EducationalBookSchoolRentRequest RentRequest { get; private set; }

    public SchoolGround MessageSender { get; private set; }

    public string Message { get; private set; }

    public SchoolRentConversationMessageStatus Status { get; private set; }

    public int? OwnerReadyGiveBook { get; set; }

    public int? ChangeRequestedBookCount { get; set; }

    public DateTime CreatedAt { get; private set; }

    public bool ViewedByReveiver { get; set; }

    private EducationalBookSchoolRentRequestConversationMessage()
    { }

    public EducationalBookSchoolRentRequestConversationMessage(Guid id)
    {
        Id = id;
    }

    public EducationalBookSchoolRentRequestConversationMessage(Guid id, 
        EducationalBookSchoolRentRequest rentRequest, 
        SchoolGround messageSender, 
        string message, 
        SchoolRentConversationMessageStatus status, 
        DateTime createdAt, 
        bool viewedByReveiver)
    {
        Id = id;
        RentRequest = rentRequest;
        MessageSender = messageSender;
        Message = message;
        Status = status;
        CreatedAt = createdAt;
        ViewedByReveiver = viewedByReveiver;
    }
}
