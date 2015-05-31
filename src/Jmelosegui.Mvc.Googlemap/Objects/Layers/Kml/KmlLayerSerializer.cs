using System;
using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class KmlLayerSerializer : LayerSerializer
    {
        private readonly KmlLayer layer;

        public KmlLayerSerializer(KmlLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            this.layer = layer;
        }

        public override string Name
        {
            get { return "kml"; }
        }

        protected override IDictionary<string, object> LayerSerialize()
        {
            IDictionary<string, object> layerDictionary = new Dictionary<string, object>();
            FluentDictionary.For(layerDictionary)
                .Add("clickable", layer.Clickable)
                .Add("preserveViewport", layer.PreserveViewport)
                .Add("screenOverlays", layer.ScreenOverlays)
                .Add("suppressInfoWindows", layer.SuppressInfoWindows)
                .Add("url", layer.Url);

            return layerDictionary;
        }
    }
}