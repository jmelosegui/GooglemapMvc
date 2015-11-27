// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Drawing;

    public class MarkerImage
    {
        private string path;

        public MarkerImage(string path, Size size, Point point, Point anchor)
        {
            this.Path = path.ToAbsoluteUrl();
            this.Size = size;
            this.Point = point;
            this.Anchor = anchor;
        }

        public Point Anchor { get; set; }

        public string Path
        {
            get
            {
                return this.path;
            }

            set
            {
                this.path = value.ToAbsoluteUrl();
            }
        }

        public Point Point { get; set; }

        public Size Size { get; set; }
    }
}
