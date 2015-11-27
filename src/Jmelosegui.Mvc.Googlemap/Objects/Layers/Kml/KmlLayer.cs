// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class KmlLayer : Layer
    {
        public KmlLayer(Map map)
            : base("kml", map)
        {
            this.Clickable = true;
            this.ScreenOverlays = true;
        }

        public bool Clickable { get; set; }

        public bool PreserveViewport { get; set; }

        public bool ScreenOverlays { get; set; }

        public bool SuppressInfoWindows { get; set; }

        public Uri Url { get; set; }

        public int ZIndex { get; set; }

        public override LayerSerializer CreateSerializer()
        {
            return new KmlLayerSerializer(this);
        }
    }
}