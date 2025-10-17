
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Common;
using System.Collections.Generic;

namespace NovinMeyar.IdentityServer.Server.Data
{
    public class ScopeStore
    {
        public static IEnumerable<ApiScope> GetApiScopes(IConfiguration configuration)
        {
            var _appSettings = configuration.Get<AppSettings>();

            return new[]
            {
                new ApiScope(Constants.Scopes.NovinMeyarApi)
            };
        }
    }
}
