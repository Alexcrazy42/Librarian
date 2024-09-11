using Domain.Entities.Acts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Acts;

public class EdBookDecommissioningConfiguration : IEntityTypeConfiguration<EdBookDecommissioning>
{
    public void Configure(EntityTypeBuilder<EdBookDecommissioning> builder)
    {
        builder.ToTable("ed_book_decommissionings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Reason)
            .HasColumnName("reason");

        builder.Property(x => x.Date)
            .HasColumnName("date");

        builder.Property(x => x.Count)
            .HasColumnName("count");

        builder.Property(x => x.InspectorApproved)
            .HasColumnName("inspector_approved");

        builder.Property(x => x.ApprovedDate)
            .HasColumnName("approved_date");
    }
}
