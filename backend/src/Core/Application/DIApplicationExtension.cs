using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DIApplicationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IClassSubjectService, ClassSubjectService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ISupplyService, SupplyService>();
        services.AddScoped<IEdBookForClassRentService, EdBookForClassRentService>();
        services.AddScoped<IEdBookForStudentRentService, EdBookForStudentService>();
        services.AddScoped<IEdBookForEmployeeRentService, EdBookForEmployeeRentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
}
