using System;

namespace Jmelosegui.Mvc.Googlemap
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
                return System.Web.VirtualPathUtility.ToAbsolute(url);
            }
            return url;
        }
    }
}