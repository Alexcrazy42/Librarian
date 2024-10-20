using Domain.Contracts.Requests.Students;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class StudentService : IStudentService
{
    private readonly IStudentRepository studentRepository;
    private readonly IClassRepository classRepository;

    public StudentService(IStudentRepository studentRepository, 
        IClassRepository classRepository)
    {
        this.studentRepository = studentRepository;
        this.classRepository = classRepository;
    }

    public async Task<IReadOnlyCollection<Student>> AddStudentsToClassAsync(AddStudentsToClassRequest request, CancellationToken ct)
    {
        var students = new List<Student>();

        var (school, schoolGround, schoolClass) = await classRepository.GetSchoolDetailsAsyncByClassIdAsync(request.ClassId, ct);

        var studentsToAdd = request.Students.Select(creationStudent
            => new Student(
                id: Guid.NewGuid(),
                isArchived: false,
                surname: creationStudent.Surname,
                name: creationStudent.Name,
                birthDate: creationStudent.BirthDate,
                patronymic: creationStudent.Patronymic,
                schoolClass: schoolClass,
                school: school,
                ground: schoolGround))
            .ToList();

        students.AddRange(studentsToAdd);

        return await studentRepository.AddStudentsToClassAsync(students, ct);
    }
}
