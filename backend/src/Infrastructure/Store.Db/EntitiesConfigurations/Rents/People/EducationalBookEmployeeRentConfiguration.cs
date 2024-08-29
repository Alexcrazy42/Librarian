using Domain.Entities.Rents.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Rents.People;

public class EducationalBookEmployeeRentConfiguration : IEntityTypeConfiguration<EducationalBookEmployeeRent>
{
    public void Configure(EntityTypeBuilder<EducationalBookEmployeeRent> builder)
    {
        builder.ToTable("ed_book_employee_rent");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey("employee_id");

        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("ed_book_id");

        builder.Property(x => x.Count).HasColumnName("count");

        builder.Property(x => x.IsArchived).HasColumnName("is_archived");

        builder.Property(x => x.StartDate).HasColumnName("start_date");

        builder.Property(x => x.EndDate).HasColumnName("end_date");


    }
}
