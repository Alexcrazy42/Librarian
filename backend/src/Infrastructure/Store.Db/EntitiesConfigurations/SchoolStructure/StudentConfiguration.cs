using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Surname)
            .HasMaxLength(100)
            .HasColumnName("surname")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(x => x.Patronymic)
            .HasMaxLength(100)
            .HasColumnName("patronymic")
            .IsRequired();

        builder.Property(x => x.IsArchived)
            .IsRequired();

        builder.HasOne(x => x.SchoolClass)
            .WithMany(schoolClass => schoolClass.Students)
            .HasForeignKey("class_id")
            .IsRequired(false);

        builder.HasOne(x => x.School)
            .WithMany(school => school.Students)
            .HasForeignKey("school_id");

        builder.HasOne(x => x.Ground)
            .WithMany(Ground => Ground.Students)
            .HasForeignKey("Ground_id");
    }
}
