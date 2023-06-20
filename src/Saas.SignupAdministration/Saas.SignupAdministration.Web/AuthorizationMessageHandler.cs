using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading;
using Saas.Shared.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Saas.SignupAdministration.Web;

public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly IEnumerable<string> _scopes;

    public AuthorizationMessageHandler(ITokenAcquisition tokenAcquisition
        , IOptions<SaasAppScopeOptions> scopes)
    {
        _tokenAcquisition = tokenAcquisition ?? throw new ArgumentNullException(nameof(tokenAcquisition));
        _scopes = scopes.Value.Scopes ?? throw new ArgumentNullException($"Scopes must be defined.");
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelToken)
    {
        HttpRequestHeaders headers = request.Headers;

        // If you have the following attribute in your interface, the authorization header will be "Bearer", not null.
        // [Headers("Authorization: Bearer")]
        AuthenticationHeaderValue authHeader = headers.Authorization;

        var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(_scopes);

        //if (authHeader != null)
        //    headers.Authorization = new AuthenticationHeaderValue(authHeader.Scheme, "TestToken");

        headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, accessToken);

        return await base.SendAsync(request, cancelToken);
    }
}
