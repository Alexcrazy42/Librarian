using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
{
    public void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.ToTable("classes");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Number)
            .HasColumnName("num");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(1);

        builder.HasOne(x => x.School)
            .WithMany(school => school.Classes)
            .HasForeignKey("school_id");

        builder.HasOne(x => x.Playground)
            .WithMany(playground => playground.Classes)
            .HasForeignKey("playground_id");

        builder.HasOne(x => x.Manager)
            .WithOne(emp => emp.ManagementClass)
            .HasForeignKey<SchoolClass>("managing_teacher_id");
    }
}
