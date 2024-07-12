using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class SubscriptionMasterConfiguration : IEntityTypeConfiguration<SubscriptionMaster>
{
    public void Configure(EntityTypeBuilder<SubscriptionMaster> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.SubscriptionMasters)
            .HasForeignKey(fk => fk.PlanId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.User)
            .WithMany(x => x.SubscriptionMasters)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
