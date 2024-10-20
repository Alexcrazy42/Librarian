﻿using Domain.Entities.UMK;

namespace Domain.Entities.SchoolStructure;

public sealed class SchoolClass
{
    public Guid Id { get; private set; }

    public int Number { get; private set; }

    public string Name { get; private set; }

    public SchoolGround Ground { get; private set; }

    public School School { get; private set; }

    public Employee? Manager { get; private set; }

    public IList<Student> Students { get; private set; } = new List<Student>();

    public IList<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public IList<ClassSubject> AddSubject(ClassSubject classSubject)
    {
        ClassSubjects.Add(classSubject);
        return ClassSubjects;
    }

    public IList<ClassSubject> AddSubjects(IList<ClassSubject> classSubjects)
    {
        foreach (var classSubject in classSubjects)
        {
            ClassSubjects.Add(classSubject);
        }
        return ClassSubjects;
    }

    private SchoolClass()
    { }

    public SchoolClass(Guid id)
    {
        Id = id;
    }

    public SchoolClass(Guid id,
        int number,
        string name,
        SchoolGround ground,
        School school)
    {
        Id = id;
        Number = number;
        Name = name;
        Ground = ground;
        School = school;
    }
}
