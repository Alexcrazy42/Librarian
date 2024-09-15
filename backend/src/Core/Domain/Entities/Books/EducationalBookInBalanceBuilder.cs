using Domain.Enums;

namespace Domain.Entities.Books;

public class EducationalBookInBalanceBuilder
{
    private EducationalBookInBalance _edBookInBalance;

    public EducationalBookInBalanceBuilder(Guid id)
    {
        _edBookInBalance = new EducationalBookInBalance(id);
    }

    public EducationalBookInBalanceBuilder SetBaseEducationalBook(Guid id)
    {
        if (id != Guid.Empty)
        {
            _edBookInBalance.SetBaseEdBook(new BaseEducationalBook(id));
        }
        
        return this;
    }

    public EducationalBookInBalanceBuilder SetPrice(decimal price)
    {
        _edBookInBalance.Price = price;
        return this;
    }

    public EducationalBookInBalanceBuilder SetCondition(BookCondition condition)
    {
        _edBookInBalance.Condition = condition;
        return this;
    }

    public EducationalBookInBalanceBuilder SetYear(int year)
    {
        _edBookInBalance.Year = year;
        return this;
    }

    public EducationalBookInBalanceBuilder SetNote(string note)
    {
        _edBookInBalance.Note = note;
        return this;
    }

    public EducationalBookInBalance Build()
    {
        return _edBookInBalance;
    }
}
