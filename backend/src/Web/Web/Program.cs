using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Store.Cache;
using Store.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Web Api",
        Version = "v1"
    });
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});

builder.Services.AddStore(builder.Configuration);
builder.Services.AddCache(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddRepositories();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
    context.Database.Migrate();
}


app.Run();
