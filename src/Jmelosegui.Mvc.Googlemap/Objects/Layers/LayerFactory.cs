using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class LayerFactory
    {
        public LayerFactory(GoogleMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            this.Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public HeatLayerBuilder AddHeatmapLayer()
        {
            var heatLayer = new HeatmapLayer(Map);

            Map.Layers.Add(heatLayer);

            return new HeatLayerBuilder(heatLayer);
        }

        public KmlLayerBuilder AddKmlLayer()
        {
            var kmlLayer = new KmlLayer(Map);

            Map.Layers.Add(kmlLayer);

            return new KmlLayerBuilder(kmlLayer);
        }

        public LayerBuilder<Layer> AddTrafficLayer()
        {
            return CreateLayerBuilder(LayerType.Traffic);
        }

        public LayerBuilder<Layer> AddBicyclingLayer()
        {
            return CreateLayerBuilder(LayerType.Bicycling);
        }

        public LayerBuilder<Layer> AddTransitLayer()
        {
            return CreateLayerBuilder(LayerType.Transit);
        }

        private LayerBuilder<Layer> CreateLayerBuilder(LayerType type)
        {
            var layer = new Layer(type.ToString(), Map);
            Map.Layers.Add(layer);
            return new LayerBuilder<Layer>(layer);
        }
    }
}