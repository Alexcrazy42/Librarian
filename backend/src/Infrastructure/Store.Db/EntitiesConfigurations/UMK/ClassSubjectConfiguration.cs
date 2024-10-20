using Domain.Entities.UMK;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Subjects;

public class ClassSubjectConfiguration : IEntityTypeConfiguration<ClassSubject>
{
    public void Configure(EntityTypeBuilder<ClassSubject> builder)
    {
        builder.ToTable("class_subjects");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Class)
            .WithMany(umkClass => umkClass.ClassSubjects)
            .HasForeignKey("umk_school_class_id");

        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey("subject_id");
    }
}
