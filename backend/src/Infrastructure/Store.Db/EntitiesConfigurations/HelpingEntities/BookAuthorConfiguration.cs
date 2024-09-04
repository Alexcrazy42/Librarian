using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.HelpingEntities;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("book_authors");

        builder.HasKey(x => x.Id);         

        builder.Property(x => x.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(BookAuthor.BookAuthorFullNameMaxLength)
            .IsRequired();

        builder.HasData(BookAuthorHelper.GetBookAuthors());
    }
}
