namespace Saas.Admin.Service.Data.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public int ProductTierId { get; set; }
    public int CategoryId { get; set; }
    public string CreatorEmail { get; set; } = string.Empty;
    public DateTime? CreatedTime { get; set; }
    public ICollection<TenantSubscription> Subscriptions { get; set; } = new List<TenantSubscription>();
    [Timestamp]
    public byte[]? ConcurrencyToken { get; set; }
}
