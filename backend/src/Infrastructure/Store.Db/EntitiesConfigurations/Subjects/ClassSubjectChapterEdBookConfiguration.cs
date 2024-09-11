using Domain.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Subjects;

public class ClassSubjectChapterEdBookConfiguration : IEntityTypeConfiguration<ClassSubjectChapterEdBook>
{
    public void Configure(EntityTypeBuilder<ClassSubjectChapterEdBook> builder)
    {
        builder.ToTable("class_subject_chapter_ed_books");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.SubjectChapter)
            .WithMany(e => e.EdBooks)
            .HasForeignKey("subject_chapter_id");

        builder.HasOne(x => x.EdBookInBalance)
            .WithMany()
            .HasForeignKey("ed_book_in_balance_id")
            .IsRequired(false);
    }
}