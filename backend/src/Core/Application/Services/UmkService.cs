using Domain.Contracts.Requests.ClassSubjects;
using Domain.Entities.Books;
using Domain.Entities.UMK;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Helping;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class UmkService : IUmkService
{
    private readonly ISchoolRepository schoolRepository;
    private readonly ISubjectRepository subjectRepository;
    private readonly IUmkRepository classSubjectRepository;

    public UmkService(ISchoolRepository schoolRepository,
        ISubjectRepository subjectRepository,
        IUmkRepository classSubjectRepository)
    {
        this.schoolRepository = schoolRepository;
        this.subjectRepository = subjectRepository;
        this.classSubjectRepository = classSubjectRepository;
    }
}
