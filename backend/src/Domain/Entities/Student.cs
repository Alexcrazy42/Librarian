using Domain.Common;

namespace Domain.Entities;

public class Student : Person
{
    public SchoolClass SchoolClass { get; set; }

	public Student(string surname,
		string name,
		string patronymic,
		SchoolClass schoolClass)
		: base(surname, name, patronymic)
	{
		SchoolClass = schoolClass;
	}
}
