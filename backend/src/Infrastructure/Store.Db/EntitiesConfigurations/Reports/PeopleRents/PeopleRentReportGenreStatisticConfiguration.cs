using Domain.Entities.Reports.PeopleRents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Reports.PeopleRents;

internal class PeopleRentReportGenreStatisticConfiguration : IEntityTypeConfiguration<PeopleRentReportGenreStatistic>
{
    public void Configure(EntityTypeBuilder<PeopleRentReportGenreStatistic> builder)
    {
        builder.ToTable("people_rent_report_genre_statistics");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Report)
            .WithMany(r => r.StaticsticsToGenres)
            .HasForeignKey("people_rent_report_id");

        builder.Property(x => x.Genre)
            .HasColumnName("genre");

        builder.Property(x => x.RentCount)
            .HasColumnName("rent_count");
    }
}
