// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;
    using Microsoft.AspNetCore.Mvc.Routing;

    public class MarkerClusteringStyles
    {
        private readonly Map map;
        private string url;

        public MarkerClusteringStyles(Map map)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = new UrlHelper(this.map.ViewContext).Content(value);
            }
        }

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