using Domain.Common.Exceptions;
using Domain.Contracts.Requests.Rents.Employees;
using Domain.Entities.Rents.People;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

internal class EdBookForEmployeeRentService : IEdBookForEmployeeRentService
{
    private readonly IEdBookForEmployeeRentRepository edBookForEmployeeRentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IEdBookInBalanceRepository edBookInBalanceRepository;

    public EdBookForEmployeeRentService(IEdBookForEmployeeRentRepository edBookForEmployeeRentRepository)
    {
        this.edBookForEmployeeRentRepository = edBookForEmployeeRentRepository;
    }

    public async Task<string> IssueEdBookToEmployeeAsync(EmployeeEdBookRentRequest request, CancellationToken ct)
    {
        var employee = await employeeRepository.GetEmployeeAsync(request.EmployeeId, ct);
        var edBookInBalance = await edBookInBalanceRepository.GetEdBookInBalanceAsync(request.EdBookInBalanceId, ct);

        var issueResponse = edBookInBalance.CanIssue(request.Count);

        if (!issueResponse.Can)
        {
            throw new CommonException($"Нельзя выдать. {issueResponse.Message}");
        }

        try
        {
            var currentRent = await edBookForEmployeeRentRepository.GetEmployeeEdBookRentAsync(request.EmployeeId, request.EdBookInBalanceId, ct);

            currentRent.PlusCount(request.Count);
            currentRent.StartDate = request.StartDate;
            currentRent.EndDate = request.EndDate;
            edBookInBalance.MinusInPlaceCount(request.Count);

            await edBookForEmployeeRentRepository.UpdateEmployeeEdBookRentAsync(currentRent, ct);

            return "Успешно!";
        }
        catch (NotFoundException)
        {
            var newRent = new EducationalBookEmployeeRent(
                Guid.NewGuid(),
                employee,
                edBookInBalance,
                request.Count, 
                false,
                false,
                request.StartDate, 
                request.EndDate
            );

            edBookInBalance.MinusInPlaceCount(request.Count);
            await edBookForEmployeeRentRepository.CreateEmployeeEdBookRentAsync(newRent, ct);

            return "Успешно!";
        }
    }

    public async Task<string> ReturnEdBookFromEmployeeAsync(IReadOnlyCollection<ReturnEdBookFromEmployeeRequest> requests, CancellationToken ct)
    {
        var rents = await edBookForEmployeeRentRepository.GetEmployeeEdBookRentsWithEmployeeAndBookAsync(
            requests.Select(x => x.Id).ToList(),ct);

        foreach (var request in requests)
        {
            var rent = rents.FirstOrDefault(x => x.Id == request.Id);
            if (rent == null) continue;

            rent.MinusCount(request.Count);

            rent.Book.PlusInPlaceCount(request.Count);
        }

        await edBookForEmployeeRentRepository.UpdateEmployeeEdBookRentsAsync(rents, ct);

        return "Успешно!";

    }
}