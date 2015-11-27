// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class ImageMapTypeSerializer : MapTypeSerializer
    {
        private readonly ImageMapType mapType;

        public ImageMapTypeSerializer(ImageMapType mapType)
            : base(mapType)
        {
            this.mapType = mapType;
        }

        public override IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = base.Serialize();

            result["repeatHorizontally"] = this.mapType.RepeatHorizontally;
            result["repeatVertically"] = this.mapType.RepeatVertically;
            result["tileSize"] = this.mapType.TileSize;
            result["tileUrlPattern"] = this.mapType.TileUrlPattern;

            return result;
        }
    }
}