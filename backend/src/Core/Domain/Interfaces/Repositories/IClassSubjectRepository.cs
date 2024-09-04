﻿using Domain.Entities.Subjects;

namespace Domain.Interfaces.Repositories;

public interface IClassSubjectRepository
{
    public Task<IReadOnlyCollection<ClassSubject>> CreateClassSubjectStructureAsync(IReadOnlyCollection<ClassSubject> classSubjects, CancellationToken ct);
}
