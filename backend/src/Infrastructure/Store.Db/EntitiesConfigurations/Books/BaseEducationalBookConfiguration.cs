using Domain.Entities.Books;
using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Books;

public class BaseEducationalBookConfiguration : IEntityTypeConfiguration<BaseEducationalBook>
{
    public void Configure(EntityTypeBuilder<BaseEducationalBook> builder)
    {
        builder.ToTable("base_ed_books");

        builder.HasKey(x => x.Id)
            .HasName("id");
        
        builder.Property(x => x.Title)
            .HasMaxLength(BaseEducationalBook.TitleMaxLength)
            .HasColumnName("title")
            .IsRequired();

        builder.HasOne(x => x.Author)
            .WithMany(author => author.Books)
            .HasForeignKey("author_id");

        builder.HasOne(x => x.Editor)
            .WithMany(editor => editor.Books)
            .HasForeignKey("editor_id");

        builder.HasOne(x => x.PublishingPlace)
            .WithMany(publishingPlace => publishingPlace.Books)
            .HasForeignKey("publishing_place_id");

        builder.HasOne(x => x.PublishingHouse)
            .WithMany(publishingHouse => publishingHouse.Books)
            .HasForeignKey("publishing_house_id");

        builder.HasOne(x => x.Subject)
            .WithMany(subject => subject.Books)
            .HasForeignKey("subject_id");


        builder.HasMany(x => x.AnotherAuthors)
            .WithMany(author => author.NonPrimaryBooks)
            .UsingEntity<Dictionary<string, string>>(
                "ed_books_another_authors",
                j => j.HasOne<BookAuthor>().WithMany().HasForeignKey("author_id"),
                j => j.HasOne<BaseEducationalBook>().WithMany().HasForeignKey("base_ed_book_id")

            );

    }
}
