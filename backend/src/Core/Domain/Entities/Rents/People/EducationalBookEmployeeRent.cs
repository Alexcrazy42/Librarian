using Domain.Entities.Books;
using Domain.Entities.Reports.PeopleRents;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents.People;

public class EducationalBookEmployeeRent
{
    public Guid Id { get; private set; }

    public Employee Employee { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public int Count { get; private set; }

    public bool IsArchived { get; private set; }

    public PeopleRentReport RentReport { get; private set; }

    public bool IsOverdue { get; private set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public void SetBook(EducationalBookInBalance book)
    {
        Book = book;
    }

    public void PlusCount(int count)
    {
        Count += count;
    }

    public void MinusCount(int count)
    {
        Count -= count;
        if (Count == 0)
        {
            IsArchived = true;
        }
    }

    private EducationalBookEmployeeRent() { }

    public EducationalBookEmployeeRent(Guid id)
    {
        Id = id;
    }

    public EducationalBookEmployeeRent(Guid id, 
        Employee employee, 
        EducationalBookInBalance book,
        int count,
        bool isArchived,
        bool isOverdue,
        DateOnly startDate,
        DateOnly endDate)
    {
        Id = id;
        Employee = employee;
        Book = book;
        Count = count;
        IsArchived = isArchived;
        IsOverdue = isOverdue;
        StartDate = startDate;
        EndDate = endDate;
    }
}
