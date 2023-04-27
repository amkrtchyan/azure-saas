using Saas.Admin.Service.Controllers;

namespace Saas.Admin.Service.Services;

public interface ISubscriptionService
{
    Task<SubscriptionDTO> GetByIdAsync(Guid subscriptionId
        , CancellationToken cancellationToken = default);
    Task<SubscriptionDTO> AddAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default);
    Task UpdateAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid subscriptionId
        , CancellationToken cancellationToken = default);
}
