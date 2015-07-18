using System;
using System.Collections.Generic;
using System.Drawing;
using Jmelosegui.Mvc.Googlemap.Objects.Layers;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class HeatLayerBuilder : LayerBuilder<HeatmapLayer>
    {
        internal HeatLayerBuilder(HeatmapLayer heatLayer) : base(heatLayer) { }

        public HeatLayerBuilder Data(Action<LocationFactory<HeatmapLayer>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<HeatmapLayer>(base.Layer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder Dissipating(bool value)
        {
            Layer.Dissipating = value;
            return this;
        }

        public HeatLayerBuilder Gradient(Action<HeatmapGradientFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            HeatmapGradientFactory factory = new HeatmapGradientFactory(base.Layer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder MaxIntensity(int value)
        {
            Layer.MaxIntensity = value;
            return this;
        }

        public HeatLayerBuilder Opacity(decimal value)
        {
            Layer.Opacity = value;
            return this;
        }

        public HeatLayerBuilder Radius(int value)
        {
            Layer.Radius = value;
            return this;
        }

        public HeatLayerBuilder BindTo<T, TLocationContainer>(IEnumerable<T> dataSource, Action<LocationBindingFactory<TLocationContainer>> itemDataBound) where TLocationContainer : class, ILocationContainer
        {
            if (dataSource == null) throw new ArgumentNullException("dataSource");
            if (itemDataBound == null) throw new ArgumentNullException("itemDataBound");

            Layer.BindTo(dataSource, itemDataBound);
            return this;
        }
    }

    public class HeatmapGradientFactory
    {
        private readonly HeatmapLayer heatmapLayer;

        internal HeatmapGradientFactory(HeatmapLayer heatmapLayer)
        {
            if (heatmapLayer == null) throw new ArgumentNullException("heatmapLayer");

            this.heatmapLayer = heatmapLayer;
        }

        public void Add(Color color)
        {
            heatmapLayer.Gradient.Add(color);
        }

        public void Add(string color)
        {
            Add(color.FromHtml());
        }
    }
}