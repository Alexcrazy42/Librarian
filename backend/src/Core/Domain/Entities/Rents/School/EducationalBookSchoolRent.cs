using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents.School;

public class EducationalBookSchoolRent
{
    public Guid Id { get; private set; }

    public EducationalBookInBalance Book { get; private set; }

    public SchoolGround OwnerSchoolGround { get; private set; }

    public SchoolGround DeptorSchoolGround { get; private set; }

    public bool CloseByDebtor { get; private set; }

    public bool CloseByOwner { get; private set; }

    public bool IsOverdue { get; private set; }

    public int Count { get; private set; }

    public DateOnly StartDate { get; private set; }

    public DateOnly ReturnDate { get; private set; }

    private EducationalBookSchoolRent() { }

    public EducationalBookSchoolRent(Guid id, 
        EducationalBookInBalance book, 
        SchoolGround ownerSchoolGround, 
        SchoolGround deptorSchoolGround, 
        bool closeByDebtor, 
        bool closeByOwner, 
        bool isOverdue, 
        int count, 
        DateOnly startDate, 
        DateOnly returnDate)
    {
        Id = id;
        Book = book;
        OwnerSchoolGround = ownerSchoolGround;
        DeptorSchoolGround = deptorSchoolGround;
        CloseByDebtor = closeByDebtor;
        CloseByOwner = closeByOwner;
        IsOverdue = isOverdue;
        Count = count;
        StartDate = startDate;
        ReturnDate = returnDate;
    }
}
