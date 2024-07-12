using Learn01.Domain.Entities;
using Learn01.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.UserProfile)
            .WithOne()
            .HasForeignKey<UserProfile>(fk => fk.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
