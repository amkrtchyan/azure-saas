namespace Saas.SignupAdministration.Web.Areas.Admin.Data;

public record RemoveUserRequest
{
    public string TenantId { get; init; } = null!;
    public string UserId { get; init; } = null!;
    public string DisplayName { get; init; } = null!;
}
