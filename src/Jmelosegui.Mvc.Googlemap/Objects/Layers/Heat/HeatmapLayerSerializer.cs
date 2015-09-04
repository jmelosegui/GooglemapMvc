using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    internal class HeatmapLayerSerializer : LayerSerializer<HeatmapLayer>
    {
        public HeatmapLayerSerializer(HeatmapLayer layer)
            : base(layer)
        {
        }

        protected override  IDictionary<string, object> LayerSerialize()
        {
            List<string> gradientCollection = Layer.Gradient.Select(color => String.Format(CultureInfo.InvariantCulture, "rgba({0}, {1}, {2}, {3})", color.R, color.G, color.B, color.A)).ToList();
            
            IDictionary<string, object> layerDictionary = new Dictionary<string, object>();
            FluentDictionary.For(layerDictionary)
                .Add("dissipating", Layer.Dissipating, () => Layer.Dissipating)
                .Add("maxIntensity", Layer.MaxIntensity, () => Layer.MaxIntensity > 0)
                .Add("opacity", Layer.Opacity, () => Layer.Opacity > 0)
                .Add("radius", Layer.Radius, () => Layer.Radius > 0)
                .Add("gradient", gradientCollection, () => Layer.Gradient.Any())
                .Add("data", Layer.Data, () => Layer.Data.Any());

            return layerDictionary;
        }
    }
}