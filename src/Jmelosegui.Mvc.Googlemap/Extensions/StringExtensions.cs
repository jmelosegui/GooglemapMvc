using System;
using System.Globalization;
using System.Linq;
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
                var uri = HttpContext.Current.Request.Url;
                return string.Format(CultureInfo.InvariantCulture, 
                    "http{0}://{1}{3}{2}",
                    (HttpContext.Current.Request.IsSecureConnection) ? "s" : "",
                    uri.Host,
                    applicationAbsoluteUrl,
                    (new [] {80, 443}.Contains(uri.Port)? "" : ":"+ uri.Port)
                    );
            }
            return url;

        }
    }
}