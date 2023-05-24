namespace Saas.Admin.Service.Data.Entities;

public class TenantSubscription
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
