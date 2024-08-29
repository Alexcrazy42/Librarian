using Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class EducationalBookInBalanceConfiguration : IEntityTypeConfiguration<EducationalBookInBalance>
{
    public void Configure(EntityTypeBuilder<EducationalBookInBalance> builder)
    {
        builder.ToTable("ed_books_in_balance");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.BaseEducationalBook)
            .WithMany()
            .HasForeignKey("base_ed_book_id");

        builder.Property(x => x.Chapter)
            .HasColumnName("chapter");

        builder.Property(x => x.Price)
            .HasColumnName("price");

        builder.Property(x => x.Condition)
            .HasColumnName("condition");

        builder.Property(x => x.Year)
            .HasColumnName("year");

        builder.Property(x => x.Note)
            .HasMaxLength(EducationalBookInBalance.NoteMaxLength)
            .HasColumnName("note");

        builder.Property(x => x.InPlaceCount)
            .HasColumnName("in_place_count");

        builder.Property(x => x.TotalCount)
            .HasColumnName("total_count");

        builder.HasOne(x => x.CurrentSchoolGround)
            .WithMany()
            .HasForeignKey("current_school_ground_id");

        builder.HasOne(x => x.BookOwnerGround)
            .WithMany()
            .HasForeignKey("book_owner_school_ground_id");

        builder.HasOne(x => x.BaseBook)
            .WithMany()
            .HasForeignKey("base_book_id")
            .IsRequired(false);


    }
}
