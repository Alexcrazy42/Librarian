using Domain.Entities.SchoolStructure;
using Domain.Enums;

namespace Domain.Entities.Books;

public sealed class EducationalBookInBalance
{
    public Guid Id { get; private set; }

    public BaseEducationalBook BaseEducationalBool { get; private set; }

    public int? Chapter { get; private set; }

    public decimal Price { get; private set; }

    public BookCondition Condition { get; private set; }

    public int Year { get; private set; }

    public string Note { get; private set; }

    public int InPlaceCount { get; private set; }

    public int TotalCount { get; private set; }

    public School School { get;  }

    public School BookOwner { get; private set; }

    private EducationalBookInBalance()
    { }

    public EducationalBookInBalance(Guid id, 
        BaseEducationalBook baseEducationalBool, 
        int? chapter, 
        decimal price, 
        BookCondition condition, 
        int year, 
        string note, 
        int inPlaceCount, 
        int totalCount, 
        School school, 
        School bookOwner)
    {
        Id = id;
        BaseEducationalBool = baseEducationalBool;
        Chapter = chapter;
        Price = price;
        Condition = condition;
        Year = year;
        Note = note;
        InPlaceCount = inPlaceCount;
        TotalCount = totalCount;
        School = school;
        BookOwner = bookOwner;
    }
}
