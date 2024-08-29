using Domain.Entities.Rents.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Store.Db.EntitiesConfigurations.Rents.School;

public class EducationalBookSchoolRentConfiguration : IEntityTypeConfiguration<EducationalBookSchoolRent>
{
    public void Configure(EntityTypeBuilder<EducationalBookSchoolRent> builder)
    {
        builder.ToTable("ed_book_school_rents");

        builder.HasKey(x => x.Id);            

        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("ed_book_id");

        builder.HasOne(x => x.OwnerSchoolGround)
            .WithMany()
            .HasForeignKey("owner_school_ground_id");

        builder.HasOne(x => x.DeptorSchoolGround)
            .WithMany()
            .HasForeignKey("deptor_school_ground_id");

        builder.Property(x => x.CloseByDebtor)
            .HasColumnName("closed_by_debtor");

        builder.Property(x => x.CloseByOwner)
            .HasColumnName("closed_by_owner");

        builder.Property(x => x.IsOverdue)
            .HasColumnName("overdue");

        builder.Property(x => x.Count)
            .HasColumnName("count");

        builder.Property(x => x.StartDate)
            .HasColumnName("start_date");

        builder.Property(x => x.ReturnDate)
            .HasColumnName("return_date");
    }
}
