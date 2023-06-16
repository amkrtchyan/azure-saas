namespace Saas.SignupAdministration.Web.Areas.Admin.Data;

public record AddUserRequest
{
    public string TenantId { get; init; } = null!;
    public string UserEmail { get; init; } = null!;
    public string ConfirmUserEmail { get; init; } = null!;
    public bool IsTenantAdmin { get; init; } = false;
    public string[] Roles { get; init; } = null!;
}
