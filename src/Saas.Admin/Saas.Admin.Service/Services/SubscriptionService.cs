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

    public async Task<List<SubscriptionDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var a = await _context.Tenants
            .SelectMany(t => t.Subscriptions)
            .ToListAsync(cancellationToken);

        return await Task.FromResult(new List<SubscriptionDTO>());
    }

    public async Task<SubscriptionDTO> AddAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default)
    {
        var entity = subscription.ToEntity();
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new SubscriptionDTO(entity);
    }

    public async Task DeleteAsync(int subscriptionId
        , CancellationToken cancellationToken = default)
    {
        var entity = await _context.FindAsync<TenantSubscription>(subscriptionId, cancellationToken);

        if (entity is not null)
            _context.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<SubscriptionDTO> GetByIdAsync(int subscriptionId
        , CancellationToken cancellationToken = default)
    {
        var entity = await _context.FindAsync<TenantSubscription>(subscriptionId, cancellationToken);

        if (entity is not null)
            return new(entity);
        else
            return null;
    }

    public Task UpdateAsync(SubscriptionDTO subscription
        , CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
