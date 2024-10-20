﻿using Domain.HelpingEntities;

namespace Domain.Interfaces.Repositories.Helping;

public interface IEditorRepository
{
    public Task<IReadOnlyCollection<Editor>> GetBookEditorsAsync(string partName, CancellationToken ct);

    public Task<Editor> CreateBookEditorIfNotExistsAsync(string fullName, CancellationToken ct);
}
