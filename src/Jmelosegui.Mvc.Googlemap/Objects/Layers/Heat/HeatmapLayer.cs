using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class HeatmapLayer : Layer, ILocationContainer
    {
        private readonly List<Location> data;

        public HeatmapLayer(GoogleMap map) : base("heatmap", map)
        {
            Gradient = new List<Color>();
            data = new List<Location>();
        }

        public IList<Location> Data
        {
            get
            {
                return data.AsReadOnly();
            }
        }

        public bool Dissipating { get; set; }

        public List<Color> Gradient { get; private set; }

        public int MaxIntensity { get; set; }

        [Range(0, 1)]
        public decimal Opacity { get; set; }

        public int Radius { get; set; }

        public override LayerSerializer CreateSerializer()
        {
            return new HeatmapLayerSerializer(this);
        }

        public void AddPoint(Location point)
        {
            if (point == null) throw new ArgumentNullException("point");
            data.Add(point);
        }

        internal void BindTo<TLocationContainer, TDataItem>(IEnumerable<TDataItem> dataSource, Action<LocationBindingFactory<TLocationContainer>> action) where TLocationContainer : class, ILocationContainer
        {
            if (action == null) throw new ArgumentNullException("action");
            if (dataSource == null) throw new ArgumentNullException("dataSource");

            var factory = new LocationBindingFactory<TLocationContainer>();

            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                factory.Binder.ItemDataBound(this as TLocationContainer, dataItem);
            }
        }

        
    }
}