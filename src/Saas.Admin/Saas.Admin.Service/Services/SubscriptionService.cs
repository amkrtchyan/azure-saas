using Saas.Admin.Service.Controllers;
using Saas.Admin.Service.Data;
using Saas.Admin.Service.Data.Entities;
using Saas.Permissions.Client;

namespace Saas.Admin.Service.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ILogger<SubscriptionService> _logger;
    private readonly TenantsContext _context;
    private readonly IPermissionsServiceClient _permissionService;

    public SubscriptionService(ILogger<SubscriptionService> logger,
        TenantsContext context,
        IPermissionsServiceClient permissionService
    )
    {
        _logger = logger;
        _context = context;
        _permissionService = permissionService;
    }

    public async Task<SubscriptionDTO> AddAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default)
    {
        var entity = subscription.ToEntity();
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new SubscriptionDTO(entity);
    }

    public Task DeleteAsync(Guid subscriptionId
        , CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<SubscriptionDTO> GetByIdAsync(Guid subscriptionId
        , CancellationToken cancellationToken = default)
    {
        var entity = await _context.FindAsync<TenantSubscription>(subscriptionId, cancellationToken);

        return new(entity);
    }

    public Task UpdateAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
