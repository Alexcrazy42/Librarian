using Domain.Entities.Rents.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Rents.School;

public class EducationalBookSchoolRentConfiguration : IEntityTypeConfiguration<EducationalBookSchoolRent>
{
    public void Configure(EntityTypeBuilder<EducationalBookSchoolRent> builder)
    {
        builder.ToTable("ed_book_school_rents");

        builder.HasKey(x => x.Id);            

        builder.HasOne(x => x.OwnerBook)
            .WithMany()
            .HasForeignKey("owner_ed_book_id");

        builder.HasOne(x => x.DebtorBook)
            .WithMany()
            .HasForeignKey("debtor_ed_book_id");

        builder.HasOne(x => x.OwnerSchoolGround)
            .WithMany()
            .HasForeignKey("owner_school_ground_id");

        builder.HasOne(x => x.DeptorSchoolGround)
            .WithMany()
            .HasForeignKey("deptor_school_ground_id");

        builder.Property(x => x.SendByDebtor)
            .HasColumnName("send_by_debtor");

        builder.Property(x => x.ReceivedByOwner)
            .HasColumnName("received_by_owner");

        builder.Property(x => x.IsOverdue)
            .HasColumnName("overdue");

        builder.Property(x => x.Count)
            .HasColumnName("count");

        builder.Property(x => x.EndRentAt)
            .HasColumnName("end_rent_at");
    }
}
