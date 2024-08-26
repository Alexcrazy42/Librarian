using Domain.Common;

namespace Domain.Entities;

public class Student : Person
{
	public Guid Id { get; set; }

	public bool IsGraduated { get; set; }

    public SchoolClass? SchoolClass { get; set; }

	public School School { get; set; }

    private Student()
    { }

	public Student(Guid id,
		bool isGraduated,
        string surname,
        string name,
        string patronymic,
        SchoolClass schoolClass,
        School school)
        : base(surname, name, patronymic)
    {
        Id = id;
        SchoolClass = schoolClass;
        School = school;
        IsGraduated = isGraduated;
    }
}
