using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("schools");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.ShortName)
            .HasMaxLength(100)
            .HasColumnName("short_name");

        builder.Property(x => x.OfficialName)
            .HasMaxLength(100)
            .HasColumnName("off_name");
    }
}
