using Domain.Common;

namespace Domain.Entities;

public class Librarian : Person
{
	public Guid Id { get; set; }

    public School School { get; private set; }

    private Librarian() : base() { }

    public Librarian(Guid id,
		string surname,
		string name,
		string patronymic, 
		School school) 
		: base(surname, name, patronymic)
	{
		Id = id;
		School = school;
	}
}
