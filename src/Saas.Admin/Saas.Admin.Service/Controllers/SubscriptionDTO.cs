using Saas.Admin.Service.Data.Entities;

namespace Saas.Admin.Service.Controllers;

public class SubscriptionDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public SubscriptionDTO(TenantSubscription subscription)
    {
        Id = subscription.Id;
        TenantId = subscription.TenantId;
        SubscriptionId = subscription.SubscriptionId;
        StartDate = subscription.StartDate;
        EndDate = subscription.EndDate;
    }

    public TenantSubscription ToEntity()
    {
        return new()
        {
            Id = this.Id,
            EndDate = this.EndDate,
            SubscriptionId = this.SubscriptionId,
            StartDate = this.StartDate,
            TenantId = this.TenantId,
        };
    }
}
