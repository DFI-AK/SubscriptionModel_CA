using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.Country)
            .WithMany(x => x.Addresses)
            .HasForeignKey(fk => fk.CountryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
