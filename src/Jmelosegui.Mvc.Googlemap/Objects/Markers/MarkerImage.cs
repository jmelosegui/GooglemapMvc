// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;
    using Microsoft.AspNetCore.Mvc.Routing;

    public class MarkerImage
    {
        private readonly Marker marker;
        private string absoluteUrl;

        public MarkerImage(Marker marker)
        {
            this.marker = marker ?? throw new ArgumentNullException(nameof(marker));
        }

        public string AbsoluteUrl
        {
            get
            {
                return this.absoluteUrl;
            }

            set
            {
                this.absoluteUrl = new UrlHelper(this.marker.Map.ViewContext).Content(value);
            }
        }

        public Point Anchor { get; set; }

        public Point Point { get; set; }

        public Size Size { get; set; }
    }
}
