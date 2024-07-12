namespace Learn01.Domain.Entities;
public class UserProfile : BaseEntity<string>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePicture { get; set; }
    public string? CountryId { get; set; }
    public string? CityId { get; set; }
    public string? OrganizationId { get; set; }
    public Country Country { get; set; } = null!;
    public City City { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    public ICollection<SubscriptionMaster> SubscriptionMasters { get; set; } = [];
    public ICollection<Transaction> Transactions { get; set; } = [];
}
