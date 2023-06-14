namespace Saas.Application.Web.Models;

public class TenantViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
}
