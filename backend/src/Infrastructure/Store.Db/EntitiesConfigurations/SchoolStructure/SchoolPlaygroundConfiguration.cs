using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class SchoolPlaygroundConfiguration : IEntityTypeConfiguration<SchoolPlayground>
{
    public void Configure(EntityTypeBuilder<SchoolPlayground> builder)
    {
        builder.ToTable("school_playgrounds");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.HasOne(x => x.School)
            .WithMany(school => school.Playgrounds)
            .HasForeignKey("school_id");
    }
}
