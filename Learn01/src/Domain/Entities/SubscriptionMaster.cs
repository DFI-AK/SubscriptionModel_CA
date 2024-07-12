namespace Learn01.Domain.Entities;
public class SubscriptionMaster : BaseEntity<string>
{
    public string? UserId { get; set; }
    public string? PlanId { get; set; }
    public int ServerCapacity { get; set; }
    public string? APIKey { get; set; }
    public DateTimeOffset? ExpiredOn { get; set; }
    public UserProfile User { get; set; } = null!;
    public SubscriptionPlan Plan { get; set; } = null!;
    public ICollection<Transaction> Transactions { get; set; } = [];
}
