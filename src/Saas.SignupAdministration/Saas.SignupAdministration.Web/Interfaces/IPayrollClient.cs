using Refit;
using System.Threading;

namespace Saas.SignupAdministration.Web;

public interface IPayrollClient
{
    [Get("/roles")]
    Task<IEnumerable<PayrollRoleModel>> GetRoles(CancellationToken cancellationToken = default);
    [Post("/users")]
    Task AddUser(PayrollUserModel user, CancellationToken cancellationToken = default);
}
