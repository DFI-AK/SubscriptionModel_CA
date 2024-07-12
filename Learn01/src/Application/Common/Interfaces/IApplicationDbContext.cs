using Learn01.Domain.Entities;

namespace Learn01.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<UserProfile> UserProfiles { get; }

    DbSet<Organization> Organizations { get; }

    DbSet<Address> Addresses { get; }

    DbSet<Country> Countries { get; }

    DbSet<City> Cities { get; }

    DbSet<SubscriptionPlan> SubscriptionPlans { get; }

    DbSet<SubscriptionMaster> SubscriptionMasters { get; }

    DbSet<Transaction> Transactions { get; }

    DbSet<PowerShellScript> PowerShellScripts { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<TodoList> TodoLists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
