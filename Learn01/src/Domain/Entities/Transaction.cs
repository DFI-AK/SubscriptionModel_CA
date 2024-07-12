namespace Learn01.Domain.Entities;
public class Transaction : BaseEntity<string>
{
    public string? MasterId { get; set; }
    public string? UserId { get; set; }
    public decimal? AmountPaid { get; set; }
    public TransactionsStatus? Status { get; set; }
    public PaymentMethods PaymentMethod { get; set; }
    public string? Comments { get; set; }
    public SubscriptionMaster Master { get; set; } = null!;
    public UserProfile User { get; set; } = null!;
}
