using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("authors");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(200);
    }
}
