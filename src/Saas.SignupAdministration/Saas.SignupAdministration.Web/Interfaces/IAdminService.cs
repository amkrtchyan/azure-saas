using Refit;
using Saas.Admin.Service.Controllers;
using System.Threading;

namespace Saas.SignupAdministration.Web.Interfaces;

public partial interface IAdminService
{
    [Get("/api/Tenants/{tenantId}/applications/{applicationId}/roles")]
    Task<ICollection<string>> GetApplicationRolesAsync(Guid tenantId, Guid applicationId, CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<TenantDTO>> TenantsAllAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<TenantDTO>> TenantsAllAsync(System.Threading.CancellationToken cancellationToken);

    /// <returns>Created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantDTO> TenantsPOSTAsync(NewTenantRequest body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Created</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantDTO> TenantsPOSTAsync(NewTenantRequest body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantDTO> TenantsGETAsync(Guid tenantId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantDTO> TenantsGETAsync(Guid tenantId, System.Threading.CancellationToken cancellationToken);

    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task TenantsPUTAsync(Guid tenantId, TenantDTO body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task TenantsPUTAsync(Guid tenantId, TenantDTO body, System.Threading.CancellationToken cancellationToken);

    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task TenantsDELETEAsync(Guid tenantId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task TenantsDELETEAsync(Guid tenantId, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantInfoDTO> TenantinfoAsync(string route);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<TenantInfoDTO> TenantinfoAsync(string route, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<UserDTO>> UsersAsync(Guid tenantId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<UserDTO>> UsersAsync(Guid tenantId, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<string>> PermissionsAllAsync(Guid tenantId, Guid userId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<string>> PermissionsAllAsync(Guid tenantId, Guid userId, System.Threading.CancellationToken cancellationToken);

    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task PermissionsPOSTAsync(Guid tenantId, Guid userId, IEnumerable<string> body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task PermissionsPOSTAsync(Guid tenantId, Guid userId, IEnumerable<string> body, System.Threading.CancellationToken cancellationToken);

    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task PermissionsDELETEAsync(Guid tenantId, Guid userId, IEnumerable<string> body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task PermissionsDELETEAsync(Guid tenantId, Guid userId, IEnumerable<string> body, System.Threading.CancellationToken cancellationToken);

    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<UserDTO> InviteAsync(Guid tenantId, string userEmail, string permission, IEnumerable<string> body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>No Content</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<UserDTO> InviteAsync(Guid tenantId, string userEmail, string permission, IEnumerable<string> body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<TenantDTO>> TenantsAsync(Guid userId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<ICollection<TenantDTO>> TenantsAsync(Guid userId, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<bool> IsValidPathAsync(string path);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<bool> IsValidPathAsync(string path, System.Threading.CancellationToken cancellationToken);

}

