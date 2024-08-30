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

        builder.Property(x => x.SupplyDate)
            .HasColumnName("supply_date");

        builder.Property(x => x.Supplier)
            .HasMaxLength(BookSupply.SupplierMaxLength)
            .HasColumnName("supplier");

        builder.Property(x => x.InvoiceNumber)
            .HasMaxLength(BookSupply.InvoiceNumberMaxLength)
            .HasColumnName("invoice_number");

        builder.HasMany(x => x.EdBooks)
            .WithOne(e => e.Supply);
    }
}
