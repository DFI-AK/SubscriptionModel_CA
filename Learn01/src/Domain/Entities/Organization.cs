namespace Learn01.Domain.Entities;
public class Organization : BaseEntity<string>
{
    public string? OrganizationName { get; set; }
    public string? OrganizationMail { get; set; }
    public string? OrganizationPhoneNumber { get; set; }
    public string? AddressId { get; set; }
    public Address Address { get; set; } = null!;
    public ICollection<UserProfile> UserProfiles { get; set; } = [];
}
