using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

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

        builder.HasOne(x => x.School)
            .WithMany(school => school.Employees)
            .HasForeignKey("school_id");

        builder.Property(x => x.EmployeeStatus)
            .IsRequired();

        builder.HasOne(x => x.ManagementClass)
            .WithOne(schoolClass => schoolClass.Manager)
            .HasForeignKey<Employee>("managing_class_id")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
