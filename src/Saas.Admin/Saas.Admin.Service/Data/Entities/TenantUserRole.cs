namespace Saas.Admin.Service.Data.Entities;

public class TenantUserRole
{
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
    public int ApplicationRoleId { get; set; }
}
