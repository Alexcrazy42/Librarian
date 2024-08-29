using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.HelpingEntities;

public class EditorConfiguration : IEntityTypeConfiguration<Editor>
{
    public void Configure(EntityTypeBuilder<Editor> builder)
    {
        builder.ToTable("book_editors");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(Editor.EditorNameMaxLength)
            .IsRequired();
    }
}
