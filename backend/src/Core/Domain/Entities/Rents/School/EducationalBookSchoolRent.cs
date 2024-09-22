using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;

namespace Domain.Entities.Rents.School;

public class EducationalBookSchoolRent
{
    public Guid Id { get; private set; }

    public EducationalBookInBalance DebtorBook { get; private set; }

    public EducationalBookInBalance OwnerBook { get; private set; }

    public SchoolGround OwnerSchoolGround { get; private set; }

    public SchoolGround DeptorSchoolGround { get; private set; }

    public bool SendByDebtor { get; private set; }

    public bool ReceivedByOwner { get; private set; }

    public bool IsOverdue { get; private set; }

    public int Count { get; private set; }

    public DateOnly EndRentAt { get; private set; }

    private EducationalBookSchoolRent() { }

    public EducationalBookSchoolRent(Guid id, 
        EducationalBookInBalance debtorBook, 
        EducationalBookInBalance ownerBook,
        SchoolGround ownerSchoolGround, 
        SchoolGround deptorSchoolGround, 
        bool sendByDebtor, 
        bool receivedByOwner, 
        bool isOverdue, 
        int count,
        DateOnly endRentAt)
    {
        Id = id;
        DebtorBook = debtorBook;
        OwnerBook = ownerBook;
        OwnerSchoolGround = ownerSchoolGround;
        DeptorSchoolGround = deptorSchoolGround;
        SendByDebtor = sendByDebtor;
        ReceivedByOwner = receivedByOwner;
        IsOverdue = isOverdue;
        Count = count;
        EndRentAt = endRentAt;
    }
}
