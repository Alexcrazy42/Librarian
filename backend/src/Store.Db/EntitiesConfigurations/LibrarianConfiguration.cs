using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations;

public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
{
    public void Configure(EntityTypeBuilder<Librarian> builder)
    {

    }
}
