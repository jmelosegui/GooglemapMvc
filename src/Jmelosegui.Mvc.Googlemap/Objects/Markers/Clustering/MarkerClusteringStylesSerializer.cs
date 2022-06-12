// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class MarkerClusteringStylesSerializer : ISerializer
    {
        private readonly MarkerClusteringStyles style;

        public MarkerClusteringStylesSerializer(MarkerClusteringStyles style)
        {
            this.style = style;
        }

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            result["url"] = this.style.Url;
            result["height"] = this.style.Height;
            result["width"] = this.style.Width;
            result["textSize"] = this.style.FontSize;
            result["textColor"] = this.style.FontColor.ToHtml();

            return result;
        }
    }
}