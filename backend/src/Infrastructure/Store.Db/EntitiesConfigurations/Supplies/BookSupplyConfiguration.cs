using Domain.Entities.Supplies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.Supplies;

public class BookSupplyConfiguration : IEntityTypeConfiguration<BookSupply>
{
    public void Configure(EntityTypeBuilder<BookSupply> builder)
    {
        builder.ToTable("book_supplies");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Ground)
            .WithMany()
            .HasForeignKey("ground_id");

        builder.HasOne(x => x.School)
            .WithMany()
            .HasForeignKey("school_id");

        builder.Property(x => x.SupplyDate)
            .HasColumnName("supply_date");

        builder.Property(x => x.Supplier)
            .HasMaxLength(BookSupply.SupplierMaxLength)
            .HasColumnName("supplier");

        builder.Property(x => x.InvoiceNumber)
            .HasMaxLength(BookSupply.InvoiceNumberMaxLength)
            .HasColumnName("invoice_number");

        builder.Property(x => x.FullFilled)
            .HasColumnName("full_filled");

        builder.HasMany(x => x.EdBooks)
            .WithOne(e => e.Supply);
    }
}
