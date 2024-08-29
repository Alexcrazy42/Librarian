using Domain.Entities.SchoolStructure;
using Domain.Enums;

namespace Domain.Entities.Books;

public sealed class EducationalBookInBalance
{
    public const int NoteMaxLength = 50;

    public Guid Id { get; private set; }

    public BaseEducationalBook BaseEducationalBook { get; private set; }

    public int? Chapter { get; private set; }

    public decimal Price { get; private set; }

    public BookCondition Condition { get; private set; }

    public int Year { get; private set; }

    public string Note { get; private set; }

    public int InPlaceCount { get; private set; }

    public int TotalCount { get; private set; }

    public SchoolGround CurrentSchoolGround { get; private set; }

    public SchoolGround BookOwnerGround { get; private set; }

    public EducationalBookInBalance? BaseBook { get; private set; }

    private EducationalBookInBalance()
    { }

    public EducationalBookInBalance(Guid id, 
        BaseEducationalBook baseEducationalBook, 
        int? chapter, 
        decimal price, 
        BookCondition condition, 
        int year, 
        string note, 
        int inPlaceCount, 
        int totalCount,
        SchoolGround currentschoolGround,
        SchoolGround bookOwnerGround)
    {
        Id = id;
        BaseEducationalBook = baseEducationalBook;
        Chapter = chapter;
        Price = price;
        Condition = condition;
        Year = year;
        Note = note;
        InPlaceCount = inPlaceCount;
        TotalCount = totalCount;
        CurrentSchoolGround = currentschoolGround;
        BookOwnerGround = bookOwnerGround;
    }
}
