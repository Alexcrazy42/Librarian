using Domain.Enums;

namespace Domain.Contracts.Requests.EdBooks;

public class CreateBaseEdBookRequest
{
    public string Title { get; set; }

    public int PublishingSeries { get; set; }

    public Language Language { get; set; }

    public Level Level { get; set; }

    public Appointment Appointment { get; set; }

    public int? Chapter { get; set; }

    public int StartClass { get; set; }

    public int EndClass { get; set; }
}
