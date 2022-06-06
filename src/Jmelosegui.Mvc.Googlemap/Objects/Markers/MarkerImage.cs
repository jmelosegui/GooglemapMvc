// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class MarkerImage
    {
        private Uri path;

        public MarkerImage(Uri absoluteUrl, Size size, Point point, Point anchor)
        {
            this.AbsoluteUrl = absoluteUrl;
            this.Size = size;
            this.Point = point;
            this.Anchor = anchor;
        }

        public Uri AbsoluteUrl { get; set; }

        public Point Anchor { get; set; }        

        public Point Point { get; set; }

        public Size Size { get; set; }
    }
}
