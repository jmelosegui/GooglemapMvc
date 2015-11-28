// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;

    public class HeatmapLayer : Layer, ILocationContainer
    {
        private readonly List<Location> data;

        public HeatmapLayer(Map map)
            : base("heatmap", map)
        {
            this.Gradient = new Collection<Color>();
            this.data = new List<Location>();
        }

        public ReadOnlyCollection<Location> Data
        {
            get
            {
                return new ReadOnlyCollection<Location>(this.data);
            }
        }

        public bool Dissipating { get; set; }

        public Collection<Color> Gradient { get; private set; }

        public int MaxIntensity { get; set; }

        public decimal Opacity { get; set; }

        public int Radius { get; set; }

        public override LayerSerializer CreateSerializer()
        {
            return new HeatmapLayerSerializer(this);
        }

        public void AddPoint(Location point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            this.data.Add(point);
        }

        internal void BindTo<TLocationContainer, TDataItem>(IEnumerable<TDataItem> dataSource, Action<LocationBindingFactory<TLocationContainer>> action)
            where TLocationContainer : class, ILocationContainer
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            var factory = new LocationBindingFactory<TLocationContainer>();

            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                factory.Binder.ItemDataBound(this as TLocationContainer, dataItem);
            }
        }
    }
}