using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class LayerFactory
    {
        private readonly GoogleMap map;

        public LayerFactory(GoogleMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            this.map = map;
        }

        public HeatLayerBuilder AddHeatmapLayer()
        {
            var heatLayer = new HeatmapLayer(map);

            map.Layers.Add(heatLayer);

            return new HeatLayerBuilder(heatLayer);
        }
    }
}