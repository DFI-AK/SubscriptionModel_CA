using System.Net;

namespace Learn01.Domain.Entities;
public class Country : BaseEntity<string>
{
    public string? CountryName { get; set; }
    public bool? Status { get; set; }
    public ICollection<UserProfile> UserProfiles { get; set; } = [];
    public ICollection<City> Cities { get; set; } = [];
    public ICollection<Address> Addresses { get; set; } = [];
}
