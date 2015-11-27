// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class HeatmapLayerSerializer : LayerSerializer<HeatmapLayer>
    {
        public HeatmapLayerSerializer(HeatmapLayer layer)
            : base(layer)
        {
        }

        protected override IDictionary<string, object> LayerSerialize()
        {
            List<string> gradientCollection = this.Layer.Gradient.Select(color => string.Format(CultureInfo.InvariantCulture, "rgba({0}, {1}, {2}, {3})", color.R, color.G, color.B, color.A)).ToList();

            IDictionary<string, object> layerDictionary = new Dictionary<string, object>();
            FluentDictionary.For(layerDictionary)
                .Add("dissipating", this.Layer.Dissipating, () => this.Layer.Dissipating)
                .Add("maxIntensity", this.Layer.MaxIntensity, () => this.Layer.MaxIntensity > 0)
                .Add("opacity", this.Layer.Opacity, () => this.Layer.Opacity > 0)
                .Add("radius", this.Layer.Radius, () => this.Layer.Radius > 0)
                .Add("gradient", gradientCollection, () => this.Layer.Gradient.Any())
                .Add("data", this.Layer.Data, () => this.Layer.Data.Any());

            return layerDictionary;
        }
    }
}