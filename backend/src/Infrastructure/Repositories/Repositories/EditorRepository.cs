using Domain.Common.Exceptions;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class EditorRepository : IEditorRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public EditorRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<Editor> CreateBookEditorIfNotExistsAsync(string fullName, CancellationToken ct)
    {
        var editor = await libraryDbContext.Editors
            .FirstOrDefaultAsync(x => x.FullName == fullName, ct);

        if (editor == null)
        {
            var newEditor = new Editor(Guid.NewGuid(), fullName);

            await libraryDbContext.Editors.AddAsync(newEditor, ct);

            return newEditor;
        }

        return editor;
    }

    public Task<IReadOnlyCollection<Editor>> GetBookEditorsAsync(string partName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}    
