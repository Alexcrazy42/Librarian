using Domain.Entities.UMK;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Subjects;

public class ClassSubjectChapterConfiguration : IEntityTypeConfiguration<ClassSubjectChapter>
{
    public void Configure(EntityTypeBuilder<ClassSubjectChapter> builder)
    {
        builder.ToTable("class_subject_chapters");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(ClassSubjectChapter.TitleMaxLength)
            .HasColumnName("title");

        builder.HasOne(x => x.ClassSubject)
            .WithMany(classSubject => classSubject.Chapters)
            .HasForeignKey("class_subject_id");
    }
}
