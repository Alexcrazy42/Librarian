using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class SchoolEmployeeConfiguration : IEntityTypeConfiguration<SchoolEmployee>
{
    public void Configure(EntityTypeBuilder<SchoolEmployee> builder)
    {

    }
}
