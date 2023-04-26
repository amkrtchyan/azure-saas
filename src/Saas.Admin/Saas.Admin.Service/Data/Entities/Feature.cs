namespace Saas.Admin.Service.Data.Entities;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
