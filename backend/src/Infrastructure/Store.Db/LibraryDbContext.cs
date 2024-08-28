using Domain.Entities.Books;
using Domain.Entities.SchoolStructure;
using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;

namespace Store.Db;

public class LibraryDbContext : DbContext
{
    public DbSet<School> Schools => Set<School>();

    public DbSet<SchoolPlayground> SchoolPlaygrounds => Set<SchoolPlayground>();

    public DbSet<Librarian> Librarians => Set<Librarian>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<SchoolClass> Classes => Set<SchoolClass>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<BaseEducationalBook> BaseEducationalBooks => Set<BaseEducationalBook>();

    public DbSet<EducationalBookInBalance> EducationalBooks => Set<EducationalBookInBalance>();

    public DbSet<Editor> Editors => Set<Editor>();

    public DbSet<PublishingHouse> PublishingHouses => Set<PublishingHouse>();

    public DbSet<PublishingPlace> PublishingPlaces => Set<PublishingPlace>();

    public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

    public DbSet<Subject> Subjects => Set<Subject>();

    public LibraryDbContext()
    { }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> contextOptions)
        : base(contextOptions)
    { }

    // TODO: refactor
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(
                    "Host=localhost; Port = 5432; Database=swipty-companies; Username=postgres; Password=123;",
                    x => x.MigrationsAssembly(typeof(LibraryDbContext).Assembly.GetName().Name));
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}
