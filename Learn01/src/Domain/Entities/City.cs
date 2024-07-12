namespace Learn01.Domain.Entities;
public class City : BaseEntity<string>
{
    public string? CityName { get; set; }
    public bool? Status { get; set; }
    public string? CountryId { get; set; }
    public ICollection<UserProfile> UserProfiles { get; set; } = [];
    public Country Country { get; set; } = null!;
}
