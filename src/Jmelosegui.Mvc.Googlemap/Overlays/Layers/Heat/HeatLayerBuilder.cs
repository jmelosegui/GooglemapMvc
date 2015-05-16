using System;
using System.Collections.Generic;
using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class HeatLayerBuilder
    {
        private readonly HeatmapLayer heatLayer;

        internal HeatLayerBuilder(HeatmapLayer heatLayer)
        {
            if (heatLayer == null) throw new ArgumentNullException("heatLayer");
            this.heatLayer = heatLayer;
        }

        public HeatLayerBuilder Data(Action<LocationFactory<HeatmapLayer>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<HeatmapLayer>(heatLayer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder Dissipating(bool value)
        {
            this.heatLayer.Dissipating = value;
            return this;
        }

        public HeatLayerBuilder Gradient(Action<HeatmapGradientFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            HeatmapGradientFactory factory = new HeatmapGradientFactory(this.heatLayer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder MaxIntensity(int value)
        {
            this.heatLayer.MaxIntensity = value;
            return this;
        }

        public HeatLayerBuilder Opacity(decimal value)
        {
            this.heatLayer.Opacity = value;
            return this;
        }

        public HeatLayerBuilder Radius(int value)
        {
            this.heatLayer.Radius = value;
            return this;
        }

        public HeatLayerBuilder BindTo<T, TLocationContainer>(IEnumerable<T> dataSource, Action<LocationBindingFactory<TLocationContainer>> itemDataBound) where TLocationContainer : class, ILocationContainer
        {
            if (dataSource == null) throw new ArgumentNullException("dataSource");
            if (itemDataBound == null) throw new ArgumentNullException("itemDataBound");

            this.heatLayer.BindTo(dataSource, itemDataBound);
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