using Domain.Entities.SchoolStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.SchoolStructure;

public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
{
    public void Configure(EntityTypeBuilder<Librarian> builder)
    {
        builder.ToTable("librarians");

        builder.HasKey(x => x.Id);            

        builder.Property(x => x.Surname)
            .HasMaxLength(100)
            .HasColumnName("surname")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(x => x.Patronymic)
            .HasMaxLength(100)  
            .HasColumnName("patronymic")
            .IsRequired();

        builder.HasOne(x => x.Ground)
            .WithMany(g => g.Librarians)
            .HasForeignKey("ground_id");

        builder.HasOne(x => x.School)
            .WithMany(s => s.Librarians)
            .HasForeignKey("school_id");

        builder.Property(x => x.IsGeneral)
            .IsRequired();
    }
}
