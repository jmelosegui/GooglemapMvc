// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class LayerFactory
    {
        public LayerFactory(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            this.Map = map;
        }

        protected Map Map { get; private set; }

        public HeatLayerBuilder AddHeatmapLayer()
        {
            var heatLayer = new HeatmapLayer(this.Map);

            this.Map.Layers.Add(heatLayer);

            return new HeatLayerBuilder(heatLayer);
        }

        public KmlLayerBuilder AddKmlLayer()
        {
            var kmlLayer = new KmlLayer(this.Map);

            this.Map.Layers.Add(kmlLayer);

            return new KmlLayerBuilder(kmlLayer);
        }

        public LayerBuilder<Layer> AddTrafficLayer()
        {
            return this.CreateLayerBuilder(LayerType.Traffic);
        }

        public LayerBuilder<Layer> AddBicyclingLayer()
        {
            return this.CreateLayerBuilder(LayerType.Bicycling);
        }

        public LayerBuilder<Layer> AddTransitLayer()
        {
            return this.CreateLayerBuilder(LayerType.Transit);
        }

        private LayerBuilder<Layer> CreateLayerBuilder(LayerType type)
        {
            var layer = new Layer(type.ToString(), this.Map);
            this.Map.Layers.Add(layer);
            return new LayerBuilder<Layer>(layer);
        }
    }
}