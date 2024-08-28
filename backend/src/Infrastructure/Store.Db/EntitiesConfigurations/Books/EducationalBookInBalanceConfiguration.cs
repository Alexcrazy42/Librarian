using Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class EducationalBookInBalanceConfiguration : IEntityTypeConfiguration<EducationalBookInBalance>
{
    public void Configure(EntityTypeBuilder<EducationalBookInBalance> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
