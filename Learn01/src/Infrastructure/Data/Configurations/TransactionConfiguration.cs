using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Learn01.Domain.Entities;

namespace Learn01.Infrastructure.Data.Configurations;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Master)
            .WithMany(x => x.Transactions)
            .HasForeignKey(fk => fk.MasterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.AmountPaid).HasPrecision(10, 2);
    }
}
