using Domain.Common.Exceptions;
using Domain.Contracts.Requests.Rents;
using Domain.Entities.Books;
using Domain.Entities.Rents.People;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class EdBookForClassRentService : IEdBookForClassRentService
{
    private readonly IClassRepository classRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IClassSubjectRepository classSubjectRepository;
    private readonly IEdBookForClassRentRepository edBookForClassRentRepository;
    private readonly IEdBookInBalanceRepository edBookInBalanceRepository;

    public EdBookForClassRentService(
        IClassRepository classRepository,
        IClassSubjectRepository classSubjectRepository,
        IStudentRepository studentRepository,
        IEdBookForClassRentRepository edBookForClassRentRepository,
        IEdBookInBalanceRepository edBookInBalanceRepository)
    {
        this.classRepository = classRepository;
        this.classSubjectRepository = classSubjectRepository;
        this.studentRepository = studentRepository;
        this.edBookForClassRentRepository = edBookForClassRentRepository;
        this.edBookInBalanceRepository = edBookInBalanceRepository;
    }

    public async Task<IReadOnlyCollection<EducationalBookStudentRent>> IssueEdBooksToClassBySubjectChapterAsync(Guid classId, Guid subjectChapterId, 
        DateOnly rentUntil, CancellationToken ct)
    {
        var classWithStudentsAndClassSubjectChapters = await classRepository.GetSchoolClassWithStudentsAndClassSubjectsChaptersAsync(classId, ct);
        
        if (!IsClassHasThisSubjectChapter(subjectChapterId, classWithStudentsAndClassSubjectChapters))
        {
            throw new CommonException("У данного класса нет такой части предмета!");
        }

        var students = classWithStudentsAndClassSubjectChapters.Students;

        var classSubjectChapterEdBookWithDetails = await classSubjectRepository.GetSubjectChapterWithEdBooksAsync(subjectChapterId, ct);

        var edBooksInBalance = classSubjectChapterEdBookWithDetails.EdBooks
            .Select(x => x.BaseEducationalBook).ToList();
        throw new NotImplementedException();

        // TODO
        //var edBooksTotalCount = edBooksInBalance.Sum(x => x.TotalCount);

        //var maxRentCount = int.Min(students.Count, edBooksTotalCount);

        //var edBookStudentRents = new List<EducationalBookStudentRent>();

        //for (int i = 0; i < maxRentCount; i++)
        //{
        //    var edBookIndex = GetEdBookIndexWhatCanGive(edBooksInBalance);
            
        //    // TODO: избавиться от continue
        //    if (edBookIndex == -1)
        //    {
        //        continue;
        //    }

        //    var student = students[i];

        //    var edBookStudentRent = new EducationalBookStudentRent(
        //        id: Guid.NewGuid(),
        //        student: student,
        //        book: edBooksInBalance[edBookIndex],
        //        count: 1,
        //        isArchived: false,
        //        isOverdue: false,
        //        startDate: DateOnly.FromDateTime(DateTime.Now),
        //        endDate: rentUntil
        //    );

        //    student.AddEdBookRent(edBookStudentRent);
        //    edBooksInBalance[edBookIndex].InPlaceCount--;
        //    edBookStudentRents.Add(edBookStudentRent);
        //}
        //return await edBookForClassRentRepository.CreateEdBooksStudentsRentsAsync(edBookStudentRents, ct);
    }

    


    private bool IsClassHasThisSubjectChapter(Guid subjectChapterId, SchoolClass schoolClass)
    {
        foreach (var classSubject in schoolClass.ClassSubjects)
        {

            foreach (var chapter in classSubject.Chapters)
            {
                if (chapter.Id == subjectChapterId)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private int GetEdBookIndexWhatCanGive(IList<EducationalBookInBalance> edBooks)
    {
        for (int i = 0; i < edBooks.Count; i++)
        {
            if (edBooks[i].InPlaceCount > 0)
            {
                return i;
            }
        }

        return -1;
    }

    private (bool canIssue, string errorMessage) CanIssueEdBookInBalance(EducationalBookInBalance edBookInBalance)
    {
        if (edBookInBalance.InPlaceCount > 0)
        {
            return (true, "");
        }

        return (false, "Нет книжек!");
    }

    
}
