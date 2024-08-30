using Domain.Entities.Reports.PeopleRents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Reports.PeopleRents;

internal class PeopleRentReportConfiguration : IEntityTypeConfiguration<PeopleRentReport>
{
    public void Configure(EntityTypeBuilder<PeopleRentReport> builder)
    {
        builder.ToTable("people_rent_reports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RentCountForClasses1To4)
            .HasColumnName("rent_count_classes_1_4");

        builder.Property(x => x.RentCountForClasses5To9)
            .HasColumnName("rent_count_classes_5_9");

        builder.Property(x => x.RentCountForClasses10To11)
            .HasColumnName("rent_count_classes_10_11");

        builder.Property(x => x.AnotherRentCount)
            .HasColumnName("another_rent_count");

        builder.Property(x => x.EdBookRentCount)
            .HasColumnName("ed_book_rent_count");

        builder.HasMany(x => x.StaticsticsToGenres)
            .WithOne(s => s.Report);

        builder.Property(x => x.Month)
            .HasColumnName("month");

        builder.Property(x => x.Year)
            .HasColumnName("year");

        builder.Property(x => x.Status)
            .HasColumnName("status");
    }
}
