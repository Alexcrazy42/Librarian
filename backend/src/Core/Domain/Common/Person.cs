namespace Domain.Common;

public abstract class Person
{
    public string Surname { get; private set; }

    public string Name { get; private set; }

    public string Patronymic { get; private set; }

    public Person() { }

    public Person(string surname, string name, string patronymic)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
    }
}
