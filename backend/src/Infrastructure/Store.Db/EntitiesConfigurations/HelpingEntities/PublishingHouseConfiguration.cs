using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.HelpingEntities;

public class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
{
    public void Configure(EntityTypeBuilder<PublishingHouse> builder)
    {
        builder.ToTable("publishing_houses");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(PublishingHouse.NameMaxLength)
            .IsRequired();
    }
}
