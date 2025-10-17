using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;

namespace NovinMeyar.Common
{
    public static class Extentions
    {
        public static void AddEnableCors(this IServiceCollection services, IConfiguration configuration, string corsName, string[] corsTrustedOrigins)
        {
            services.AddCors(options =>
                options.AddPolicy(name: corsName,
                    builder =>
                    {
                        builder
                        //.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(corsTrustedOrigins);
                    })
                );
        }
        public static string GetDescription<T>(this T enumVal) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return string.Empty;

            var description = enumVal.ToString();
            var fieldInfo = enumVal.GetType().GetField(description);

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return description;
        }
    }
}
