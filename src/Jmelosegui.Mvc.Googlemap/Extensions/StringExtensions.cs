// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Web;

    internal static class StringExtensions
    {
        public static bool HasValue(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        public static string ToAbsoluteUrl(this string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.IndexOf("://", StringComparison.Ordinal) > -1)
            {
                return url;
            }

            string newUrl = string.Empty;

            if (url.StartsWith("~"))
            {
                newUrl = VirtualPathUtility.ToAbsolute(url);
            }

            Uri originalUri = HttpContext.Current.Request.Url;
            var result = $"{originalUri.Scheme}://{originalUri.Authority}{newUrl}";

            return result;
        }
    }
}