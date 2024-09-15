using Domain.Common.Exceptions;
using Domain.Contracts.Requests.Rents.Students;
using Domain.Entities.Rents.People;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class EdBookForStudentService : IEdBookForStudentRentService
{
    private readonly IEdBookForStudentRentRepository edBookForStudentRentRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IEdBookInBalanceRepository edBookInBalanceRepository;

    public async Task<string> IssueEdBookToStudentAsync(StudentEdBookRentRequest request, CancellationToken ct)
    {
        var student = await studentRepository.GetStudentAsync(request.StudentId, ct);
        var edBookInBalance = await edBookInBalanceRepository.GetEdBookInBalanceAsync(request.EdBookInBalanceId, ct);

        var issueResponse = edBookInBalance.CanIssue(request.Count);

        if (!issueResponse.Can)
        {
            throw new CommonException($"Нельзя выдать ученику. {issueResponse.Message}");
        }

        try
        {
            var currentRent = await edBookForStudentRentRepository.GetStudentEdBookRentAsync(request.StudentId, request.EdBookInBalanceId, ct);

            currentRent.PlusCount(request.Count);
            currentRent.StartDate = request.StartDate;
            currentRent.EndDate = request.EndDate;
            edBookInBalance.MinusInPlaceCount(request.Count);

            await edBookForStudentRentRepository.UpdateStudentEdBookRentAsync(currentRent, ct);

            return "Успешно!";
        }
        catch (NotFoundException)
        {
            var newRent = new EducationalBookStudentRent(
                Guid.NewGuid(),
                student,
                edBookInBalance,
                request.Count,
                false,
                false,
                request.StartDate,
                request.EndDate);

            edBookInBalance.MinusInPlaceCount(request.Count);

            await edBookForStudentRentRepository.CreateStudentEdBookRentAsync(newRent, ct);

            return "Успешно!";
        }
    }

    public async Task<string> ReturnEdBookFromStudentAsync(IReadOnlyCollection<ReturnEdBookFromStudentRequest> requests, CancellationToken ct)
    {
        var rents = await edBookForStudentRentRepository.GetStudentEdBookRentsWithStudentAndBookAsync(
            requests.Select(x => x.Id).ToList(),
            ct);

        foreach (var request in requests)
        {
            var rent = rents.FirstOrDefault(x => x.Id == request.Id);
            if (rent == null) continue;

            rent.MinusCount(request.Count);

            rent.Book.PlusInPlaceCount(request.Count);
        }

        await edBookForStudentRentRepository.UpdateStudentEdBookRentsAsync(rents, ct);

        return "Успешно!";
    }
}
