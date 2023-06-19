namespace Saas.Admin.Service.Data.Entities;

public class Application
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<TenantApplicationRole> Roles { get; set; } = new List<TenantApplicationRole>();
}
