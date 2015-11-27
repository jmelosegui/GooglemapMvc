// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class HeatmapGradientFactory
    {
        private readonly HeatmapLayer heatmapLayer;

        internal HeatmapGradientFactory(HeatmapLayer heatmapLayer)
        {
            if (heatmapLayer == null)
            {
                throw new ArgumentNullException(nameof(heatmapLayer));
            }

            this.heatmapLayer = heatmapLayer;
        }

        public void Add(Color color)
        {
            this.heatmapLayer.Gradient.Add(color);
        }

        public void Add(string color)
        {
            this.Add(color.FromHtml());
        }
    }
}