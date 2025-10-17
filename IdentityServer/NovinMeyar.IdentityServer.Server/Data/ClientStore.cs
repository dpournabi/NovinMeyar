using IdentityModel;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Common;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace NovinMeyar.IdentityServer.Server.Data
{
    internal static class ClientStore
    {
        public static IEnumerable<Client> Get(IConfiguration configuration)
        {
            var _appSettings = configuration.Get<AppSettings>();
            var result = new List<Client>();

            var adminClient = new Client
            {
                ClientName = "Novin Meyar",
                ClientId = "7868d015-6c79-4da4-b789-8b4d40611946",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    Constants.Scopes.NovinMeyarApi,
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    StandardScopes.Phone,
                    Constants.IdentityResources.Role
                },
                AccessTokenType = AccessTokenType.Jwt,
                AllowOfflineAccess = true,
                AllowedCorsOrigins = _appSettings.CORSTrustedOrigins,
                AllowAccessTokensViaBrowser=true,
                AlwaysIncludeUserClaimsInIdToken = true,
                RequireClientSecret=false,
                AccessTokenLifetime = 60 * 60 * 24,
                IdentityTokenLifetime = 60 * 60 * 24,
                Enabled=true,
                Claims = new ClientClaim[]
                {
                    new ClientClaim(JwtClaimTypes.Role, AssessorsManager.Administrator)
                },
                //Refresh token settings
                RefreshTokenExpiration = TokenExpiration.Sliding,
                SlidingRefreshTokenLifetime = 60 * 60 * 24,//1 day
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                UpdateAccessTokenClaimsOnRefresh = true,
            };
            result.Add(adminClient);

            
            return result;
        }
    }
}
