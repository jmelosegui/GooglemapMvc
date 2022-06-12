// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;
    using Microsoft.AspNetCore.Mvc.Routing;

    public class ImageMapType : MapTypeBase
    {
        private readonly Map map;
        private string tileUrlPatter;

        public ImageMapType(Map map)
        {
            this.TileSize = new Size(256, 256);
            this.RepeatHorizontally = true;
            this.RepeatVertically = false;

            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public Size TileSize { get; set; }

        public string TileUrlPattern
        {
            get
            {
                return this.tileUrlPatter;
            }

            set
            {
                this.tileUrlPatter = new UrlHelper(this.map.ViewContext).Content(value);
            }
        }

        public bool RepeatHorizontally { get; set; }

        public bool RepeatVertically { get; set; }

        public override ISerializer CreateSerializer()
        {
            return new ImageMapTypeSerializer(this);
        }
    }
}
