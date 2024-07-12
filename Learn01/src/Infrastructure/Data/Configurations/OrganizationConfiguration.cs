using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.Property(x => x.OrganizationName).IsRequired().HasMaxLength(200);

        builder.Property(x => x.OrganizationMail).IsRequired();

        builder.HasOne(x => x.Address)
            .WithMany(x => x.Organizations)
            .HasForeignKey(fk => fk.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
