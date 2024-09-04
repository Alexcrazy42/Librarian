namespace Domain.Common;

public abstract class Person
{
    public string Surname { get; set; }

    public string Name { get; set; }

    public string? Patronymic { get; set; }

    public Person() { }

    public Person(string surname, string name, string? patronymic = null)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
    }
}
