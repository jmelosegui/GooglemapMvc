// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class KmlLayerSerializer : LayerSerializer<KmlLayer>
    {
        public KmlLayerSerializer(KmlLayer layer)
            : base(layer)
        {
        }

        protected override IDictionary<string, object> LayerSerialize()
        {
            IDictionary<string, object> layerDictionary = new Dictionary<string, object>();
            FluentDictionary.For(layerDictionary)
                .Add("clickable", this.Layer.Clickable)
                .Add("preserveViewport", this.Layer.PreserveViewport)
                .Add("screenOverlays", this.Layer.ScreenOverlays)
                .Add("suppressInfoWindows", this.Layer.SuppressInfoWindows)
                .Add("url", this.Layer.Url.AbsoluteUri);

            return layerDictionary;
        }
    }
}