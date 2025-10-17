using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace NovinMeyar.IdentityServer.Server
{
    public static class Extentions
    {
        public static List<FieldInfo> GetFields(this object obj) => GetFields(obj.GetType());
        public static List<FieldInfo> GetFields(this Type t) => t.GetFields().ToList();
        public static List<PropertyInfo> GetProperties(this object obj) => GetProperties(obj.GetType());
        public static List<PropertyInfo> GetProperties(this Type t) => t.GetProperties().ToList();
        public static string UserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserName");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
