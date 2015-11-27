// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class MarkerClusteringStyles
    {
        public Uri Url { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int FontSize { get; set; }

        public Color FontColor { get; set; }

        public ISerializer CreateSerializer()
        {
            return new MarkerClusteringStylesSerializer(this);
        }
    }
}