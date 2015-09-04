using System;
using System.Globalization;
using System.Web;

namespace Jmelosegui.Mvc.GoogleMap
{
    internal static class StringExtensions
    {
        public static bool HasValue(this string source)
        {
            return !String.IsNullOrWhiteSpace(source);
        }

        public static string ToAbsoluteUrl(this string url)
        {
            if (url.IndexOf("://", StringComparison.Ordinal) == -1)
            {
                string applicationAbsoluteUrl = System.Web.VirtualPathUtility.ToAbsolute(url);

                return string.Format(CultureInfo.InvariantCulture, 
                    "http{0}://{1}{2}",
                    (HttpContext.Current.Request.IsSecureConnection) ? "s" : "",
                    HttpContext.Current.Request.Url.Host,
                    applicationAbsoluteUrl
                );
            }
            return url;

        }
    }
}