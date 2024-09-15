using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Helping;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;
using Repositories.Repositories.Helping;

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
        services.AddScoped<IBaseEdBookRepository, BaseEdBookRepository>();
        services.AddScoped<IEdBookInBalanceRepository, EdBookInBalanceRepository>();
        services.AddScoped<IEdBookForClassRentRepository, EdBookForClassRentRepository>();
        services.AddScoped<IEdBookForStudentRentRepository, EdBookForStudentRentRepository>();
        services.AddScoped<IEdBookForEmployeeRentRepository, EdBookForEmployeeRentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}
