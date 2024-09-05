using Domain.Contracts.Responses.Editors;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Helping;

[ApiController]
[Route("api/book-editors")]
public class BookEditorController : ControllerBase
{

    private readonly IEditorRepository editorRepository;

    public BookEditorController(IEditorRepository editorRepository)
    {
        this.editorRepository = editorRepository;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<EditorResponse>> GetEditorAsync(string partName, CancellationToken ct)
    {
        var bookEditors = await editorRepository.GetBookEditorsAsync(partName, ct);

        return bookEditors.Select(bookEditor => new EditorResponse()
        {
            Id = bookEditor.Id,
            FullName = bookEditor.FullName
        }).ToList();
    }

    [HttpPost]
    public async Task<EditorResponse> CreateEditorIfNotExistsAsync(string fullName, CancellationToken ct)
    {
        var bookEditor = await editorRepository.CreateBookEditorIfNotExistsAsync(fullName, ct);

        return new EditorResponse()
        {
            Id = bookEditor.Id,
            FullName = bookEditor.FullName
        };
    }
}
