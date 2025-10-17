using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace NovinMeyar.Notification.Api
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

        public static string GetContentType(this string ext) => MimeTypes().FirstOrDefault(x => x.Key == ext)?.Value;
      
        public class MimeType 
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        private static IEnumerable<MimeType> MimeTypes()
        {
            yield return new MimeType { Key= ".jpg", Value= "image/jpeg" };
            yield return new MimeType { Key = ".jpeg", Value = "image/jpeg" };
            yield return new MimeType { Key = ".png", Value = "image/png" };
            yield return new MimeType { Key = ".pdf", Value = "application/pdf" };
            yield return new MimeType { Key = ".rar", Value = "application/vnd.rar" };
            yield return new MimeType { Key = ".zip", Value = "application/zip" };
            yield return new MimeType { Key = ".xls", Value = "application/vnd.ms-excel" };
            yield return new MimeType { Key = ".xlsx", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };

            //Reference: https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types
        }

    }
}
