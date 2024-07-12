using Learn01.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data.Configurations;
public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.Property(x => x.PlanName).IsRequired().HasMaxLength(120);

        builder.Property(x => x.Price).HasPrecision(10, 2);

        builder.Property(x => x.Discount).HasPrecision(10, 2);
    }
}
