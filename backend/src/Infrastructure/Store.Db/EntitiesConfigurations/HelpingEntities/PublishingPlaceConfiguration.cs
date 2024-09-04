using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.HelpingEntities;

public class PublishingPlaceConfiguration : IEntityTypeConfiguration<PublishingPlace>
{
    public void Configure(EntityTypeBuilder<PublishingPlace> builder)
    {
        builder.ToTable("publishing_places");

        builder.HasKey(x => x.Id);            

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(PublishingPlace.NameMaxLength)
            .IsRequired();

        builder.HasData(PublishingPlaceHelper.GetPublishingPlaces());
    }
}
