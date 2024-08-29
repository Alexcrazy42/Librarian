using Domain.Entities.RentRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.RentRequests;

internal class EducationalBookSchoolRentRequestConversationMessageConfiguration : IEntityTypeConfiguration<EducationalBookSchoolRentRequestConversationMessage>
{
    public void Configure(EntityTypeBuilder<EducationalBookSchoolRentRequestConversationMessage> builder)
    {
        builder.ToTable("ed_books_school_rent_request_conversation_messages");

        builder.HasKey(x => x.Id);            

        builder.HasOne(x => x.RentRequest)
            .WithMany(rentRequest => rentRequest.Messages)
            .HasForeignKey("ed_book_rent_request_id");

        builder.HasOne(x => x.MessageSender)
            .WithMany()
            .HasForeignKey("school_ground_sender_id");

        builder.Property(x => x.Message)
            .HasMaxLength(EducationalBookSchoolRentRequestConversationMessage.MessageMaxLength)
            .HasColumnName("message");

        builder.Property(x => x.Status)
            .HasColumnName("status");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(x => x.ViewedByReveiver)
            .HasColumnName("viewed_by_receiver");
    }
}
