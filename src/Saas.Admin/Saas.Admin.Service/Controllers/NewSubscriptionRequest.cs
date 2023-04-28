using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Controllers;

public class NewSubscriptionRequest
{
    public Guid TenantId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    internal SubscriptionDTO ToSubscription()
    {
        SubscriptionDTO subscription = new()
        {
            TenantId = TenantId,
            SubscriptionId = SubscriptionId,
            StartDate = StartDate,
            EndDate = EndDate,
        };

        return subscription;
    }
}
