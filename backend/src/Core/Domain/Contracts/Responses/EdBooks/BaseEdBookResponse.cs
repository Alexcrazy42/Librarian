using Domain.Enums;

namespace Domain.Contracts.Responses.EdBooks;

public class BaseEdBookResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public int PublishingSeries { get; set; }

    public Language Language { get; set; }

    public Level Level { get; set; }

    public Appointment Appointment { get; set; }

    public int? Chapter { get; set; }

    public int StartClass { get; set; }

    public int EndClass { get; set; }
}
