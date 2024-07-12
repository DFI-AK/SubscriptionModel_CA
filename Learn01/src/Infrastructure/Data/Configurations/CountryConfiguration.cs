using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.Property(x => x.CountryName).IsRequired().HasMaxLength(100);
    }
}
