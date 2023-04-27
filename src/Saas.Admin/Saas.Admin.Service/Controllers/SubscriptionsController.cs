using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saas.Permissions.Client;
using System.Net.Mime;

namespace Saas.Admin.Service.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IPermissionsServiceClient _permissionsServiceClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;

    public SubscriptionsController(
        ISubscriptionService subscriptionService,
        IPermissionsServiceClient permissionService,
        IHttpContextAccessor httpContextAccessor,
        ILogger<TenantsController> logger)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _subscriptionService = subscriptionService;
        _permissionsServiceClient = permissionService;
    }

    /// <summary>
    /// Add a new tenant
    /// </summary>
    /// <param name="subscription"></param>
    /// <returns></returns>
    /// <remarks>
    /// <para><b>Requires:</b> Authenticated user</para>
    /// <para>This call needs a user to make admin of this tenant.  TBD explicitly pass in the user ID or 
    /// make the current user the admin (would prevent a third party creating tenants on behalf of user)</para>
    /// </remarks>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(TenantDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [Authorize]
    public async Task<ActionResult<SubscriptionDTO>> Post(SubscriptionDTO subscription, CancellationToken cancellationToken)
    {
        try
        {
            if (!Guid.TryParse(User?.GetNameIdentifierId(), out var userId))
            {
                throw new InvalidOperationException("The the User Name Identifier must be a Guid.");
            }

            var tenantSubscription = await _subscriptionService.AddAsync(subscription, cancellationToken);

            //_logger.LogInformation("Created a new tenant {NewTenantName} with URL {NewTenantRoute}, and ID {NewTenantID}", tenant.Name, tenant.Route, tenant.Id);

            return CreatedAtAction(nameof(Post), new { tenantId = tenantSubscription.Id }, tenantSubscription);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest((ex.InnerException ?? ex).Message);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Problem creating subscription for tenant with ID {TenantId}", subscription.TenantId);
            throw;
        }
    }
}
