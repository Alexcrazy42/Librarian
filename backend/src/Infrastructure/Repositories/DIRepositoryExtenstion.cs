using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace Repositories;

public static class DIRepositoryExtenstion
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IClassSubjectRepository, ClassSubjectRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<ISupplyRepository, SupplyRepository>();
        services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
        services.AddScoped<IEditorRepository, EditorRepository>();
        services.AddScoped<IPublishingRepository, PublishingRepository>();
        return services;
    }
}
