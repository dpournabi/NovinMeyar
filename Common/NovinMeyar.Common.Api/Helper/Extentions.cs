using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace NovinMeyar.Common.Api
{
    public static class Extentions
    {
        public static string FirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string LastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static long BranchId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("BranchId");
            return (claim != null) ? Convert.ToInt64(claim.Value) : -1;
        }
        public static string BranchName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("BranchName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string UserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static bool CurrentRoleIsAdmin(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CurrentRoleIsAdmin");
            return Convert.ToBoolean(claim.Value);
        }

        public static DateTime? DateOfBirth(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.DateOfBirth);
            return (claim != null) ? Convert.ToDateTime(claim.Value) : (DateTime?)null;
        }
        public static bool IsActive(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsActive");
            return Convert.ToBoolean(claim.Value);
        }
        public static string ImageUrl(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ImageUrl");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetLevelCharacter(this int digit)
        {
            var dictionary = new Dictionary<int, string>();
            int counter = 0;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(counter, c.ToString());
                counter++;
            }
            return dictionary.First(x => x.Key == digit).Value;
        }
    }
}
