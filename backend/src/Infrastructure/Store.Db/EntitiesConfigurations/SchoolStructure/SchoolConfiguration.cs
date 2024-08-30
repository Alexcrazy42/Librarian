using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("schools");

        builder.HasKey(x => x.Id);            

        builder.Property(x => x.ShortName)
            .HasMaxLength(100)
            .HasColumnName("short_name");

        builder.Property(x => x.OfficialName)
            .HasMaxLength(100)
            .HasColumnName("off_name");

        builder.HasMany(x => x.Grounds)
            .WithOne(s => s.School);

        builder.HasMany(x => x.Classes)
            .WithOne(c => c.School);

        builder.HasMany(x => x.Librarians)
            .WithOne(l => l.School);
    }
}
