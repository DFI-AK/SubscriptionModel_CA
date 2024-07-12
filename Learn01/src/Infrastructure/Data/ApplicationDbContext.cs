using System.Reflection;
using Learn01.Application.Common.Interfaces;
using Learn01.Domain.Entities;
using Learn01.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Learn01.Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<Address> Addresses => Set<Address>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<City> Cities => Set<City>();

    public DbSet<SubscriptionPlan> SubscriptionPlans => Set<SubscriptionPlan>();

    public DbSet<SubscriptionMaster> SubscriptionMasters => Set<SubscriptionMaster>();

    public DbSet<Transaction> Transactions => Set<Transaction>();

    public DbSet<PowerShellScript> PowerShellScripts => Set<PowerShellScript>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.HasDefaultSchema("Licence");
    }
}
