using NovinMeyar.Cartabl.Api.Enums;
using NovinMeyar.Common;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace NovinMeyar.Cartabl.Api
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

        public static string RoleName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CurrentUserRoles");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static bool CurrentRoleIsAdmin(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CurrentRoleIsAdmin");
            return Convert.ToBoolean(claim.Value);
        }
        public static string CurrentUserRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CurrentUserRoles");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string MakeConfirmationString(this int value)
        {
            var currentStatus = (CartablStates)value;
            var sb = new StringBuilder();

            if (currentStatus.HasFlag(CartablStates.TechnicalExpertAccept))
                sb.AppendLine($"{CartablStates.TechnicalExpertAccept.GetDescription()} \n");

            if (currentStatus.HasFlag(CartablStates.TechnicalManagerAccept))
                sb.AppendLine($"{CartablStates.TechnicalManagerAccept.GetDescription()} \n");

            if (currentStatus.HasFlag(CartablStates.BranchManagerAccept))
                sb.AppendLine($"{CartablStates.BranchManagerAccept.GetDescription()} \n");

            if (currentStatus.HasFlag(CartablStates.TechnicalManagerReject))
                sb.AppendLine($"{CartablStates.TechnicalManagerReject.GetDescription()} \n");

            return sb.ToString();
        }
    }
}
