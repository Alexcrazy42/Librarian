using Domain.Contracts.Responses.Helping.BookAuthors;
using Domain.Interfaces.Repositories.Helping;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Helping;

[ApiController]
[Route("api/authors")]
public class BookAuthorController : ControllerBase
{
    private readonly IBookAuthorRepository bookRepository;

    public BookAuthorController(IBookAuthorRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<BookAuthorResponse>> GetBookAuthorAsync(string partName, CancellationToken ct)
    {
        var bookAuthors = await bookRepository.GetBookAuthorsAsync(partName, ct);

        return bookAuthors.Select(bookAuthor => new BookAuthorResponse()
        {
            Id = bookAuthor.Id,
            FullName = bookAuthor.FullName
        }).ToList();
    }

    [HttpPost]
    public async Task<BookAuthorResponse> CreateBookAuthorIfNotExistAsync(string fullName, CancellationToken ct)
    {
        var bookAuthor = await bookRepository.CreateBookAuthorIfNotExistsAsync(fullName, ct);

        return new BookAuthorResponse()
        {
            Id = bookAuthor.Id,
            FullName = bookAuthor.FullName
        };
    }
}
