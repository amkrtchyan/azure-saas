namespace Saas.Admin.Service.Data.Entities;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxUserNumber { get; set; }
    public decimal MonthlyPayment { get; set; }
    public ICollection<Feature> Features { get; set; } = new List<Feature>();
}
