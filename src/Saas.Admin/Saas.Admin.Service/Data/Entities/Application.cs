namespace Saas.Admin.Service.Data.Entities;

public class Application
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
