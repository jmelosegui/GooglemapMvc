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
            if (url.StartsWith("~", StringComparison.Ordinal))
            {
                return VirtualPathUtility.ToAbsolute(url);
            }

            return url;
        }
    }
}