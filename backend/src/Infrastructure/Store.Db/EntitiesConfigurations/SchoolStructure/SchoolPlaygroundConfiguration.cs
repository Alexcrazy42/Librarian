using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class SchoolGroundConfiguration : IEntityTypeConfiguration<SchoolGround>
{
    public void Configure(EntityTypeBuilder<SchoolGround> builder)
    {
        builder.ToTable("school_Grounds");

        builder.HasKey(x => x.Id)
            .HasName("id");

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.HasOne(x => x.School)
            .WithMany(school => school.Grounds)
            .HasForeignKey("school_id");
    }
}
