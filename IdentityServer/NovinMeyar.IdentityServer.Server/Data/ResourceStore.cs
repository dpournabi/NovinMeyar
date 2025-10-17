using IdentityModel;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Common;
using System.Collections.Generic;

namespace NovinMeyar.IdentityServer.Server.Data
{
    internal static class ResourceStore
    {
        public static IEnumerable<IdentityResource> GetIdentityResources(IConfiguration configuration)
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = Constants.IdentityResources.Role,
                    DisplayName = "Roles",
                    UserClaims = { JwtClaimTypes.Role }
                }
                 //new IdentityResource(name: "profile",
                 //                     userClaims: new[] { "name", "email", "website" },
                 //                     displayName: "Profile data")
            };
        }

        public static IEnumerable<ApiResource> GetApiResources(IConfiguration configuration)
        {
            var _appSettings = configuration.Get<AppSettings>();

            return new[]
            {
                new ApiResource
                {
                    Name = Constants.Scopes.NovinMeyarApi,
                    Scopes = new [] { Constants.Scopes.NovinMeyarApi, JwtClaimTypes.Role },
                    UserClaims = new [] { JwtClaimTypes.Role }
                }
            };
        }
    }
}
