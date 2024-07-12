using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.Country)
            .WithMany(x => x.Cities)
            .HasForeignKey(fk => fk.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CityName).IsRequired().HasMaxLength(100);
    }
}

