// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class HtmlHelperExtension
    {
        public static MapBuilder GoogleMap(this IHtmlHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            return new MapBuilder(helper.ViewContext);
        }
    }
}