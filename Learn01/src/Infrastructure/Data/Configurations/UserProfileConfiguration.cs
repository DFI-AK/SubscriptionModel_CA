using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(145);
        builder.Property(x => x.LastName).HasMaxLength(145);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.UserProfiles)
            .HasForeignKey(fk => fk.CountryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
