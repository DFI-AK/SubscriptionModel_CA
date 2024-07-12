namespace Learn01.Domain.Entities;
public class Address : BaseEntity<string>
{
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? CountryId { get; set; }
    public Country Country { get; set; } = null!;
    public ICollection<Organization> Organizations { get; set; } = [];
}

