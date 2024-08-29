using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
{
    public void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.ToTable("classes");

        builder.HasKey(x => x.Id);            

        builder.Property(x => x.Number)
            .HasColumnName("num");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(1);

        builder.HasOne(x => x.Ground)
            .WithMany()
            .HasForeignKey("Ground_id");

        builder.HasOne(x => x.Manager)
            .WithOne()
            .HasForeignKey<SchoolClass>("managing_teacher_id")
            .IsRequired(false);
    }
}
