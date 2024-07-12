namespace Learn01.Domain.Entities;
public class SubscriptionPlan : BaseEntity<string>
{
    public string? PlanName { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public SubscriptionType PlanType { get; set; }
    public ICollection<SubscriptionMaster> SubscriptionMasters { get; set; } = [];
}
