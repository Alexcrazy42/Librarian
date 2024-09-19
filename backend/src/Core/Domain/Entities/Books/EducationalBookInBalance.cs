using Domain.Common.Exceptions;
using Domain.Contracts.Responses.EdBooks;
using Domain.Entities.Acts;
using Domain.Entities.SchoolStructure;
using Domain.Entities.Supplies;
using Domain.Enums;

namespace Domain.Entities.Books;

public sealed class EducationalBookInBalance
{
    public const int NoteMaxLength = 50;
    private decimal _price;
    private BookCondition _condition;
    private int _year;
    private string _note;
    private int _inPlaceCount;
    private int _totalCount;
    private bool _inStock;
    private BaseEducationalBook _baseEdBook;
    private SchoolGround _debtorGround;

    public Guid Id { get; private set; }

    public BaseEducationalBook BaseEducationalBook
    {
        get
        {
            return _baseEdBook;
        }
        set
        {
            if (value != null)
            {
                _baseEdBook = value;
            }
        }
    }

    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value <= 0) throw new CommonException("Значение должно быть больше 0");
            
            _price = value;   
        }
    }

    public BookCondition Condition
    {
        get
        {
            return _condition;
        }
        set
        {
            if (value != BookCondition.Unknown)
            {
                _condition = value;
            }
        }
    }

    public int Year
    {
        get
        {
            return _year;
        }
        set
        {
            if (_year != 0)
            {
                _year = value;
            }
            
        }
    }

    public string Note
    {
        get
        {
            return _note;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _note = value;
            }
            
        }
    }


    public int InPlaceCount
    {
        get
        {
            return _inPlaceCount;
        }
        set
        {
            if (value <= 0)
            {
                throw new CommonException("Значение должно быть больше 0!");
            }
            _inPlaceCount = value;
        }
    }

    public int TotalCount
    {
        get
        {
            return _totalCount;
        }
        set
        {
            if (value <= 0)
            {
                throw new CommonException("Значение должно быть больше 0!");
            }
            _totalCount = value;
        }
    }

    public bool InStock
    {
        get
        {
            return _inStock;
        }
        init
        {
            _inStock = value;
        }
    }

    public SchoolGround CurrentSchoolGround { get; private set; }

    public SchoolGround BookOwnerGround { get; private set; }

    public SchoolGround? DebtorSchoolGround
    {
        get
        {
            return _debtorGround;
        }
        set
        {
            if (value != null)
            {
                _debtorGround = value;
            }
        }
    }

    public BookSupply Supply { get; private set; }

    public EdBookDecommissioning? Decommissioning { get; private set; }

    public void MinusInPlaceCount(int count)
    {
        _inPlaceCount -= count;
    }

    public void PlusInPlaceCount(int count)
    {
        _inPlaceCount += count;
    }

    public void SetBaseEdBook(BaseEducationalBook book)
    {
        BaseEducationalBook = book;
    }

    public CanIssueEdBookInBalanceResponse CanIssue(int count)
    {
        if (InPlaceCount >= count)
        {
            return new CanIssueEdBookInBalanceResponse(true);
        }
        return new CanIssueEdBookInBalanceResponse(false, "Нет книг на балансе!");
    }

    private EducationalBookInBalance()
    { }
    
    public EducationalBookInBalance(Guid id)
    {
        Id = id;
    }

    public EducationalBookInBalance(
        Guid id, 
        BaseEducationalBook baseEducationalBook,
        decimal price, 
        BookCondition condition,
        int year,
        string note, 
        int inPlaceCount, 
        int totalCount,
        bool inStock,
        SchoolGround currentschoolGround,
        SchoolGround bookOwnerGround,
        BookSupply supply
    )
    {
        Id = id;
        BaseEducationalBook = baseEducationalBook;
        Price = price;
        Year = year;
        Condition = condition;
        Note = note;
        InPlaceCount = inPlaceCount;
        TotalCount = totalCount;
        CurrentSchoolGround = currentschoolGround;
        BookOwnerGround = bookOwnerGround;
        Supply = supply;
        InStock = inStock;
    }
}
