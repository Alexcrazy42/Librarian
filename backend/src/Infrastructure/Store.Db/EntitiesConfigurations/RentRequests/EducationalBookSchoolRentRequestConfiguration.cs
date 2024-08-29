using Domain.Entities.RentRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.RentRequests;

public class EducationalBookSchoolRentRequestConfiguration : IEntityTypeConfiguration<EducationalBookSchoolRentRequest>
{
    public void Configure(EntityTypeBuilder<EducationalBookSchoolRentRequest> builder)
    {
        builder.ToTable("ed_book_school_rent_requests");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.HasOne(x => x.DebtorSchoolGround)
            .WithMany()
            .HasForeignKey("debtor_school_ground_id");

        builder.HasOne(x => x.OwnerSchoolGround)
            .WithMany()
            .HasForeignKey("owner_school_ground_id");

        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("ed_book_in_balance_id");

        builder.Property(x => x.RequestingBookCount)
            .HasColumnName("requesting_book_count");

        builder.Property(x => x.OwnerReadyGiveBookCount)
            .HasColumnName("owner_ready_give_book_count");

        builder.Property(x => x.RequestStatus)
            .HasColumnName("request_status");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at");

        builder.HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey("created_by");

        builder.Property(x => x.ViewedUpdatesByRequestedSide)
            .HasColumnName("viewed_updates_requested_side");

        builder.Property(x => x.ViewedUpdatesByRequestingSide)
            .HasColumnName("viewed_updates_requesting_side");

        builder.Property(x => x.ResolvedByRequestingSide)
            .HasColumnName("resolved_requesting_side");

        builder.Property(x => x.ResolvedByRequestedSide)
            .HasColumnName("resolved_requested_side");

        builder.Property(x => x.SendByOwner)
            .HasColumnName("send_by_owner");

        builder.Property(x => x.ReceivedByDebtor)
            .HasColumnName("received_by_debtor");
    }
}
