using System.Net.Mime;
using Saas.Identity.Authorization.Attribute;
using Saas.Identity.Authorization.Model.Kind;
using Saas.Identity.Authorization.Requirement;
using Saas.Permissions.Client;

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
        ILogger<SubscriptionsController> logger)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _subscriptionService = subscriptionService;
        _permissionsServiceClient = permissionService;
    }

    /// <summary>
    /// Get all subscriptions in the system
    /// </summary>
    /// <returns>List of all subscriptions</returns>
    /// <remarks>
    /// <para><b>Requires:</b> admin.subscription.read</para>
    /// <para>This call will return all the subscriptions in the system.</para>
    /// </remarks>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    [SaasAuthorize<SaasTenantPermissionRequirement, TenantPermissionKind>(TenantPermissionKind.Read)]
    public async Task<ActionResult<IEnumerable<SubscriptionDTO>>> GetAllSubscriptions(CancellationToken cancellationToken)
    {
        try
        {
            List<SubscriptionDTO> allSubscriptions = (await _subscriptionService.GetAllAsync(cancellationToken)).ToList();
            
            return Ok(allSubscriptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Problem retrieving all subscriptions");
            throw;
        }
    }

    /// <summary>
    /// Get a subscription by subscription ID
    /// </summary>
    /// <param name="subscriptionId">Int representing the subscription</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Information about the subscription</returns>
    /// <remarks>
    /// <para><b>Requires:</b> admin.subscription.read  or  {subscriptionID}.subscription.read</para>
    /// <para>Will return details of a single subscription, if user has access.</para>
    /// </remarks>
    [HttpGet("{subscriptionId}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [SaasAuthorize<SaasTenantPermissionRequirement, TenantPermissionKind>(TenantPermissionKind.Read, routingRestrictionKeyName: "subscriptionId")]
    public async Task<ActionResult<SubscriptionDTO>> Get(int subscriptionId
        , CancellationToken cancellationToken)
    {
        _logger.LogDebug("{User} requested subscription with ID {SubscriptionID}", User?.Identity?.Name, subscriptionId);
        try
        {
            SubscriptionDTO subscription = await _subscriptionService.GetByIdAsync(subscriptionId, cancellationToken);

            return Ok(subscription);
        }
        catch (ItemNotFoundExcepton)
        {
            _logger.LogDebug("Was not able to find subscription with ID {TeantntID}", subscriptionId);
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Problem retrieving subscription with ID {SubscriptionID}", subscriptionId);
            throw;
        }
    }

    /// <summary>
    /// Add a new subscription
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// <para><b>Requires:</b> Authenticated user</para>
    /// <para>This call needs a user to make admin of this subscription.  TBD explicitly pass in the user ID or 
    /// make the current user the admin (would prevent a third party creating subscriptions on behalf of user)</para>
    /// </remarks>
    [HttpPost()]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [Authorize]
    public async Task<ActionResult<SubscriptionDTO>> Post(NewSubscriptionRequest request
        , CancellationToken cancellationToken)
    {
        try
        {
            if (!Guid.TryParse(User?.GetNameIdentifierId(), out var userId))
            {
                throw new InvalidOperationException("The the User Name Identifier must be a Guid.");
            }

            var subscriptionSubscription = await _subscriptionService.AddAsync(request.ToSubscription(), cancellationToken);

            //_logger.LogInformation("Created a new subscription {NewSubscriptionName} with URL {NewSubscriptionRoute}, and ID {NewSubscriptionID}", subscription.Name, subscription.Route, subscription.Id);

            return CreatedAtAction(nameof(Post), new { subscriptionId = subscriptionSubscription.Id }, subscriptionSubscription);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest((ex.InnerException ?? ex).Message);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Problem creating subscription for subscription with ID {SubscriptionId}", request.SubscriptionId);
            throw;
        }
    }

    /// <summary>
    /// Update an existing subscription
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <param name="subscriptionDTO"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>
    /// <para><b>Requires:</b> admin.subscription.write  or  {subscriptionID}.subscription.write</para>
    /// </remarks>
    [HttpPut("{subscriptionId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [SaasAuthorize<SaasTenantPermissionRequirement, TenantPermissionKind>(TenantPermissionKind.Update, "subscriptionId")]
    public async Task<IActionResult> PutSubscription(Guid subscriptionId, SubscriptionDTO subscriptionDTO
        , CancellationToken cancellationToken)
    {
        if (subscriptionId != subscriptionDTO.Id)
        {
            return BadRequest();
        }
        
        try
        {
            await _subscriptionService.UpdateAsync(subscriptionDTO, cancellationToken);
        }
        catch (ItemNotFoundExcepton ex)
        {
            _logger.LogWarning(ex, "Unable to find subscription {SubscriptionID}", subscriptionId);
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Problem updating subscription {SubscriptionID}", subscriptionId);
            throw;
        }

        return NoContent();
    }

    /// <summary>
    /// Deletes a subscription
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{subscriptionId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [SaasAuthorize<SaasTenantPermissionRequirement, TenantPermissionKind>(TenantPermissionKind.Delete, "subscriptionId")]
    public async Task<IActionResult> DeleteSubscription(int subscriptionId, CancellationToken cancellationToken)
    {
        try
        {
            await _subscriptionService.DeleteAsync(subscriptionId, cancellationToken);
        }
        catch (ItemNotFoundExcepton ex)
        {
            _logger.LogWarning(ex, "Unable to find subscription {SubscriptionID}", subscriptionId);
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Unable to delete subscription {SubscriptionID}", subscriptionId);
            throw;
        }

        return NoContent();
    }
}
