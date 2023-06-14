using Refit;

namespace Saas.Application.Web.Interfaces;

public interface IPayrollClient
{
    [Get("/roles")]
    Task<IEnumerable<string>> GetRoles(CancellationToken cancellationToken = default);
    [Post("/users")]
    Task AddUser(PayrollUserModel user, CancellationToken cancellationToken = default);
}
