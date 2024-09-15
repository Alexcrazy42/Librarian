using Domain.Common.Exceptions;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories.Helping;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories.Helping;

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

            libraryDbContext.Editors.Add(newEditor);
            await libraryDbContext.SaveChangesAsync(ct);

            return newEditor;
        }

        return editor;
    }

    public async Task<IReadOnlyCollection<Editor>> GetBookEditorsAsync(string partName, CancellationToken ct)
    {
        return await libraryDbContext.Editors
            .Where(x => x.FullName.ToUpper().Contains(partName.ToUpper()))
            .ToListAsync(ct);
    }
}
