// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;

    public class HeatLayerBuilder : LayerBuilder<HeatmapLayer>
    {
        internal HeatLayerBuilder(HeatmapLayer heatLayer)
            : base(heatLayer)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public HeatLayerBuilder Data(Action<LocationFactory<HeatmapLayer>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new LocationFactory<HeatmapLayer>(this.Layer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder Dissipating(bool value)
        {
            this.Layer.Dissipating = value;
            return this;
        }

        public HeatLayerBuilder Gradient(Action<HeatmapGradientFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            HeatmapGradientFactory factory = new HeatmapGradientFactory(this.Layer);
            action(factory);
            return this;
        }

        public HeatLayerBuilder MaxIntensity(int value)
        {
            this.Layer.MaxIntensity = value;
            return this;
        }

        public HeatLayerBuilder Opacity(decimal value)
        {
            this.Layer.Opacity = value;
            return this;
        }

        public HeatLayerBuilder Radius(int value)
        {
            this.Layer.Radius = value;
            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public HeatLayerBuilder BindTo<T, TLocationContainer>(IEnumerable<T> dataSource, Action<LocationBindingFactory<TLocationContainer>> itemDataBound)
            where TLocationContainer : class, ILocationContainer
        {
            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            if (itemDataBound == null)
            {
                throw new ArgumentNullException(nameof(itemDataBound));
            }

            this.Layer.BindTo(dataSource, itemDataBound);
            return this;
        }
    }
}