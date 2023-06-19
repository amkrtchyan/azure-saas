namespace Saas.Admin.Service.Data.Entities;

public class TenantApplicationRole
{
    public int Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid ApplicationId { get; set; }
    public string Role { get; set; }
}
