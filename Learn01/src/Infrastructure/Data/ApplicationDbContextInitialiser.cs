using Learn01.Domain.Constants;
using Learn01.Domain.Enums;
using Learn01.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Learn01.Infrastructure.Data;
public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "ayush.kumar@defactoinfotech.com", Email = "ayush.kumar@defactoinfotech.com" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Test@123");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.SubscriptionPlans.Any())
        {
            await _context.SubscriptionPlans.AddRangeAsync([
                new(){
                    PlanName="Base plan",
                    Description="This is base plan.",
                    Price= 100.59M,
                    PlanType=SubscriptionType.Base,
                    IsActive=true
                },
                new(){
                    PlanName="Trial plan",
                    Description="This is trial plan.",
                    Price= 0,
                    PlanType=SubscriptionType.Trail,
                    IsActive=true
                },
                new(){
                    PlanName="Custom plan",
                    Description="This is custom plan.",
                    Price= 100.59M,
                    PlanType=SubscriptionType.Custom,
                    IsActive=true
                }
                ]);
            await _context.SaveChangesAsync();
        }

        if (!_context.Countries.Any())
        {
            await _context.Countries.AddRangeAsync([
                new(){
                    CountryName = "India",
                    Status=true,
                },new(){
                    CountryName = "USA",
                    Status=true,
                },new(){
                    CountryName = "Australia",
                    Status=true,
                },new(){
                    CountryName = "West Indies",
                    Status=true,
                },new(){
                    CountryName = "Pakistan",
                    Status=true,
                },
                ]);
            await _context.SaveChangesAsync();
        }
    }
}
