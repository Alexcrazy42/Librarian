using Domain.Contracts.Requests.School;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class SchoolService : ISchoolService
{
    private readonly ISchoolRepository schoolRepository;

    public SchoolService(ISchoolRepository schoolRepository)
    {
        this.schoolRepository = schoolRepository;
    }

    public async Task<School> CreateSchoolStructureAsync(CreateSchoolStructureRequest request, CancellationToken cancellationToken)
    {
        var school = new School(
            id: Guid.NewGuid(),
            shortName: request.ShortName,
            officialName: request.OfficialName
        );

        var grounds = new List<SchoolGround>();
        var allClasses = new List<SchoolClass>();
        var allLibrarians = new List<Librarian>();

        foreach(var ground in request.Grounds)
        {
            var schoolGround = new SchoolGround(
                id: Guid.NewGuid(),
                name: ground.Name,
                school: school
            );

            var classes = ground.Classes.Select(x => new SchoolClass(
                id: Guid.NewGuid(),
                number: x.Number,
                name: x.Name,
                subjectCount: x.SubjectCount,
                ground: schoolGround,
                school: school
            )).ToList();

            var librarians = ground.Librarians.Select(x => new Librarian(
                id: Guid.NewGuid(),
                surname: x.Surname,
                name: x.Name,
                patronymic: x.Patronymic,
                isGeneral: x.IsGeneral,
                ground: schoolGround,
                school: school
            )).ToList();

            schoolGround.Librarians = librarians;
            schoolGround.Classes = classes;

            grounds.Add(schoolGround);
            allClasses.AddRange(classes);
            allLibrarians.AddRange(librarians);
        }

        school.Grounds = grounds;
        school.Librarians = allLibrarians;
        school.Classes = allClasses;

        return await schoolRepository.CreateSchoolStructureAsync(school, cancellationToken);
    }
}
