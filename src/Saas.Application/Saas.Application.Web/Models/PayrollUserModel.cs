namespace Saas.Application.Web.Models;

public class PayrollUserModel
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Guid? UserObjectId { get; set; }
    public string[]? Roles { get; set; }
}
