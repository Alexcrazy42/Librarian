using Domain.Enums;

namespace Domain.Entities.Reports.PeopleRents;

public class PeopleRentReport
{
    public Guid Id { get; private set; }

    public int RentCountForClasses1To4 { get; private set; }

    public int RentCountForClasses5To9 { get; private set; }

    public int RentCountForClasses10To11 { get; private set; }

    public int AnotherRentCount { get; private set; }

    public int EdBookRentCount { get; private set; }

    public PeopleRentReportStatus Status { get; private set; }

    public int? Month { get; private set; }

    public int Year { get; private set; }

    public IReadOnlyCollection<PeopleRentReportGenreStatistic> StaticsticsToGenres { get; private set; } = new List<PeopleRentReportGenreStatistic>();

    private PeopleRentReport() { }

    public PeopleRentReport(Guid id, 
        int rentCountForClasses1To4, 
        int rentCountForClasses5To9, 
        int rentCountForClasses10To11, 
        int anotherRentCount, 
        int edBookRentCount, 
        int? month,
        int year,
        IReadOnlyCollection<PeopleRentReportGenreStatistic> staticsticsToGenres)
    {
        Id = id;
        RentCountForClasses1To4 = rentCountForClasses1To4;
        RentCountForClasses5To9 = rentCountForClasses5To9;
        RentCountForClasses10To11 = rentCountForClasses10To11;
        AnotherRentCount = anotherRentCount;
        EdBookRentCount = edBookRentCount;
        Month = month;
        Year = year;
        StaticsticsToGenres = staticsticsToGenres;
    }
}
