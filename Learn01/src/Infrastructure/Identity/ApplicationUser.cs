using Learn01.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Learn01.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    public UserProfile UserProfile { get; set; } = null!;
}
