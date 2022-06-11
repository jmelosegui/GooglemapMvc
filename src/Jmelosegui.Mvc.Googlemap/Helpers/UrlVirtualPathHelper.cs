// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    internal static class UrlVirtualPathHelper
    {
        public static void AssertVirtualPath(string parameter, string parameterName)
        {
            if (!parameter.HasValue())
            {
                throw new ArgumentNullException(nameof(parameterName), "Can not be null or empty");
            }

            if (!parameter.StartsWith("~/", StringComparison.Ordinal))
            {
                throw new ArgumentException("Source must be a virtual path which should starts with tile and slash", parameterName);
            }
        }
    }
}
