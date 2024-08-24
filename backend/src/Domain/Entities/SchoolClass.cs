namespace Domain.Entities;

public sealed class SchoolClass
{
    public string Name { get; set; }

    public SchoolClass(string name)
    {
        Name = name;
    }
}
