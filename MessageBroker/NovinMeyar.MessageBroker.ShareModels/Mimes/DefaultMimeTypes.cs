using System.Collections.Generic;
using System.Linq;

namespace NovinMeyar.Common.Mimes
{
    public class MimeType
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public static class DefaultMimeTypes
    {
        public static string GetContentType(this string ext) => MimeTypes().FirstOrDefault(x => x.Key == ext)?.Value;

        
        private static IEnumerable<MimeType> MimeTypes()
        {
            yield return new MimeType { Key = ".jpg", Value = "image/jpeg" };
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
