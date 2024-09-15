using Domain.Entities.Books;
using Domain.Entities.Reports.PeopleRents;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents.People;

public class EducationalBookStudentRent
{
    public Guid Id { get; private set; }

    public Student Student { get; private set; }

    public EducationalBookInBalance Book { get; set; }

    public int Count { get; private set; }

    public bool IsArchived { get; private set; }

    public PeopleRentReport? RentReport { get; private set; }

    public bool IsOverdue { get; set; }

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

    private EducationalBookStudentRent() { }

    public EducationalBookStudentRent(Guid id)
    {
        Id = id;
    }

    public EducationalBookStudentRent(Guid id, 
        Student student, 
        EducationalBookInBalance book, 
        int count,
        bool isArchived,
        bool isOverdue,
        DateOnly startDate, 
        DateOnly endDate)
    {
        Id = id;
        Student = student;
        Book = book;
        Count = count;
        IsArchived = isArchived;
        IsOverdue = isOverdue;
        StartDate = startDate;
        EndDate = endDate;
    }
}
