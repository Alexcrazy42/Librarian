using Domain.Entities.UMK;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.UMK;

public class UMKClassConfiguration : IEntityTypeConfiguration<UMKClass>
{
    public void Configure(EntityTypeBuilder<UMKClass> builder)
    {
        builder.ToTable("umk_classes");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.SchoolClass)
            .WithOne()
            .HasForeignKey<UMKClass>("school_class_id");

        builder.Property(x => x.StudentCount)
            .HasColumnName("student_count");
    }
}
