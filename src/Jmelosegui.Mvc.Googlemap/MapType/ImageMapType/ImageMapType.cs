// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class ImageMapType : MapTypeBase
    {
        public ImageMapType()
        {
            this.TileSize = new Size(256, 256);
            this.RepeatHorizontally = true;
            this.RepeatVertically = false;
        }

        public Size TileSize { get; set; }

        public Uri TileUrlPattern { get; set; }

        public bool RepeatHorizontally { get; set; }

        public bool RepeatVertically { get; set; }

        public override ISerializer CreateSerializer()
        {
            return new ImageMapTypeSerializer(this);
        }
    }
}
