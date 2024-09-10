using Domain.Entities.Rents.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Rents.People;

public class EducationalBookStudentRentConfiguration : IEntityTypeConfiguration<EducationalBookStudentRent>
{
    public void Configure(EntityTypeBuilder<EducationalBookStudentRent> builder)
    {
        builder.ToTable("ed_book_student_rent");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Student)
            .WithMany(s => s.EdBookRents)
            .HasForeignKey("student_id");
    }
}
