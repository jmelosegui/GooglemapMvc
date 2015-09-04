using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class KmlLayer : Layer
    {
        public KmlLayer(GoogleMap map) : base("kml", map)
        {
            Clickable = true;
            ScreenOverlays = true;
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