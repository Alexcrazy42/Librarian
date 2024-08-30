using Domain.Enums;

namespace Domain.Entities.Reports.PeopleRents;

public class PeopleRentReportGenreStatistic
{
    public Guid Id { get; private set; }

    public PeopleRentReport Report { get; private set; }

    public ImaginativeBookGenre Genre { get; private set; }

    public int RentCount { get; private set; }

    private PeopleRentReportGenreStatistic() { }

    public PeopleRentReportGenreStatistic(Guid id, 
        PeopleRentReport report, 
        ImaginativeBookGenre genre, 
        int rentCount)
    {
        Id = id;
        Report = report;
        Genre = genre;
        RentCount = rentCount;
    }
}
