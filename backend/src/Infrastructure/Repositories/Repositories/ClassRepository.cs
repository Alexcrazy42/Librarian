﻿using Domain.Common.Exceptions;
using Domain.Entities.SchoolStructure;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class ClassRepository : IClassRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public ClassRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<SchoolClass> GetClassWithManagerAsync(Guid classId, CancellationToken ct)
    {
        return await libraryDbContext.Classes
            .Include(x => x.Manager)
            .FirstOrDefaultAsync(x => x.Id == classId, ct)
            ?? throw new NotFoundException("Класс не найден!");
    }

    public async Task<SchoolClass> GetSchoolClassWithStudentsAndClassSubjectsChaptersAsync(Guid classId, CancellationToken ct)
    {
        return await libraryDbContext.Classes
            .Include(x => x.Students)
            .Include(x => x.ClassSubjects)
                .ThenInclude(classSubject => classSubject.Chapters)
            .FirstOrDefaultAsync(x => x.Id == classId, ct)
            ?? throw new NotFoundException("Класс не найден!");
    }

    public async Task<(School School, SchoolGround SchoolGround, SchoolClass Class)> GetSchoolDetailsAsyncByClassIdAsync(Guid classId, CancellationToken ct)
    {
        var schoolClass = await libraryDbContext.Classes
            .Include(x => x.School)
            .Include(x => x.Ground)
            .FirstOrDefaultAsync(x => x.Id == classId, ct)
            ?? throw new NotFoundException("Класс не найден!");

        return (schoolClass.School, schoolClass.Ground, schoolClass);
    }
}
