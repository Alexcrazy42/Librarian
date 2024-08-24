using Domain.Common;

namespace Domain.Entities;

public class Librarian : Person
{
    public School School { get; private set; }

	public Librarian(string surname,
		string name,
		string patronymic, 
		School school) 
		: base(surname, name, patronymic)
	{
		School = school;
	}
}
