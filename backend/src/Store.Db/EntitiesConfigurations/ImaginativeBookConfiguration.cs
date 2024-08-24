using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class ImaginativeBookConfiguration : IEntityTypeConfiguration<ImaginativeBook>
{
    public void Configure(EntityTypeBuilder<ImaginativeBook> builder)
    {

    }
}
