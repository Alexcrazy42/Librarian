using Domain.Contracts.Requests.EdBooks;
using Domain.Entities.Books;
using Domain.HelpingEntities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Repositories.Repositories;

internal class BaseEdBookRepository : IBaseEdBookRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public BaseEdBookRepository(LibraryDbContext libraryDbContext)
    {
        this.libraryDbContext = libraryDbContext;
    }

    public async Task<IReadOnlyCollection<BaseEducationalBook>> GetSimilarBookAsync(GetSimilarBaseEdBookRequest request, CancellationToken ct)
    {
        var similarBooks = await GetSimilarBooksByCreateRequestAsync(request, ct);

        return similarBooks.ToList();
    }

    public async Task<Guid> CreateBookAfterUserSureWhatAnotherVariantsNotSuitAsync(CreateBaseEdBookRequest request, CancellationToken ct)
    {
        var getFaimiliarBaseEdBookRequest = new GetSimilarBaseEdBookRequest()
        {
            AuthorId = request.AuthorId,
            EditorId = request.EditorId,
            Title = request.Title,
            PublishingPlaceId = request.PublishingPlaceId,
            PublishingHouseId = request.PublishingHouseId,
            PublishingSeries = request.PublishingSeries,
            Language = request.Language,
            Level = request.Level,
            Appointment = request.Appointment,
            Chapter = request.Chapter,
            SubjectId = request.SubjectId,
            StartClass = request.StartClass,
            EndClass = request.EndClass,
            LeaveFromFederalBooksListAt = request.LeaveFromFederalBooksListAt,
            AnotherAuthorsIds = request.AnotherAuthorsIds
        };

        var similarBooks = await GetSimilarBooksByCreateRequestAsync(getFaimiliarBaseEdBookRequest, ct);
        
        if (similarBooks.Count > 0)
        {
            return similarBooks[0].Id;
        }

        var author = new BookAuthor(request.AuthorId, null);
        var editor = new Editor(request.EditorId, null);
        var publishingPlace = new PublishingPlace(request.PublishingPlaceId, null);
        var publishingHouse = new PublishingHouse(request.PublishingHouseId, null);
        var subject = new Subject(request.SubjectId, null);
        var anotherAuthors = request.AnotherAuthorsIds
            .Select(x => new BookAuthor(x, null))
            .ToList();

        libraryDbContext.Attach(author);
        libraryDbContext.Attach(editor);
        libraryDbContext.Attach(publishingPlace);
        libraryDbContext.Attach(publishingHouse);
        libraryDbContext.Attach(subject);
        foreach (var anotherAuthor in anotherAuthors)
        {
            libraryDbContext.Attach(anotherAuthor);
        }


        var baseEdBook = new BaseEducationalBook(
            id: Guid.NewGuid(),
            author: author,
            editor: editor,
            title: request.Title,
            publishingPlace: publishingPlace,
            publishingHouse: publishingHouse,
            publishingSeries: request.PublishingSeries,
            language: request.Language,
            level: request.Level,
            appointment: request.Appointment,
            subject: subject,
            startClass: request.StartClass,
            endClass: request.EndClass,
            anotherAuthors: anotherAuthors,
            leaveFromFederalBooksListAt: request.LeaveFromFederalBooksListAt,
            chapter: request.Chapter
        );

        libraryDbContext.BaseEducationalBooks
            .Add(baseEdBook);

        await libraryDbContext.SaveChangesAsync(ct);


        return baseEdBook.Id;
    }
    
    
    private async Task<IList<BaseEducationalBook>> GetSimilarBooksByCreateRequestAsync(GetSimilarBaseEdBookRequest request, CancellationToken ct)
    {
        var query = libraryDbContext.BaseEducationalBooks
            .AsQueryable();

        if (request.AuthorId != null)
        {
            query = query.Where(x => x.Author.Id == request.AuthorId);
        }

        if (request.EditorId != null)
        {
            query = query.Where(x => x.Editor.Id == request.EditorId);
        }

        if (request.Title != null)
        {
            query = query.Where(x => x.Title.Contains(request.Title));
        }

        if(request.PublishingPlaceId != null)
        {
            query = query.Where(x => x.PublishingPlace.Id == request.PublishingPlaceId);
        }

        if (request.PublishingHouseId != null)
        {
            query = query.Where(x => x.PublishingHouse.Id == request.PublishingHouseId);
        }

        if (request.PublishingSeries != null)
        {
            query = query.Where(x => x.PublishingSeries == request.PublishingSeries);
        }

        if (request.Language != null)
        {
            query = query.Where(x => x.Language == request.Language);
        }

        if (request.Level != null)
        {
            query = query.Where(x => x.Level == request.Level);
        }

        if (request.Appointment != null)
        {
            query = query.Where(x => x.Appointment == request.Appointment);
        }

        if (request.Chapter != null)
        {
            query = query.Where(x => x.Chapter == request.Chapter);
        }

        if (request.StartClass != null)
        {
            query = query.Where(x => x.StartClass == request.StartClass);
        }

        if (request.EndClass != null)
        {
            query = query.Where(x => x.EndClass == request.EndClass);
        }

        if (request.LeaveFromFederalBooksListAt != null)
        {
            query = query
                .Where(x => x.LeaveFromFederalBooksListAt == request.LeaveFromFederalBooksListAt);
        }

        var anotherAuthorIds = request.AnotherAuthorsIds;

        if (anotherAuthorIds.Count > 0)
        {
            query = query.Include(x => x.AnotherAuthors);
        }

        // TODO: rewrite by sql render
        var familiarBooksWithoitAnotherAuthorsCompare = await query.ToListAsync(ct);
        var result = new List<BaseEducationalBook>();

        foreach (var book in familiarBooksWithoitAnotherAuthorsCompare)
        {
            if (book.AnotherAuthors.Count == 0)
            {
                result.Add(book);
            }
            else if (book.AnotherAuthors
                .Select(x => x.Id)
                .Any(id => anotherAuthorIds.Contains(id)))
            {
                result.Add(book);
            }
        }

        return result;
    }
}
