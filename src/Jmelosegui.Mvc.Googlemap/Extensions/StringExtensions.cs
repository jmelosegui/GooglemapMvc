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
            if (url.StartsWith("~"))
            {
                return VirtualPathUtility.ToAbsolute(url);
            }
            return url;
        }
    }
}