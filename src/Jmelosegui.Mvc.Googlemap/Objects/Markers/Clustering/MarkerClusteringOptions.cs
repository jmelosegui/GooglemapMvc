// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class MarkerClusteringOptions : ISerializer
    {
        public MarkerClusteringOptions()
        {
            this.MaxZoom = 12;
            this.GridSize = 60;
            this.HideSingleGroupMarker = true;
            this.ZoomOnClick = true;
            this.CustomStyles = new Collection<MarkerClusteringStyles>();
        }

        public int MaxZoom { get; set; }

        public int GridSize { get; set; }

        public bool AverageCenter { get; set; }

        public bool ZoomOnClick { get; set; }

        public bool HideSingleGroupMarker { get; set; }

        public Collection<MarkerClusteringStyles> CustomStyles { get; }

        public IDictionary<string, object> Serialize()
        {
            var customStyles = new List<IDictionary<string, object>>();

            if (this.CustomStyles.Any())
            {
                this.CustomStyles.Each(cs => customStyles.Add(cs.CreateSerializer().Serialize()));
            }

            IDictionary<string, object> result = new Dictionary<string, object>();
            FluentDictionary.For(result)
                .Add("MaxZoom", this.MaxZoom)
                .Add("GridSize", this.GridSize)
                .Add("AverageCenter", this.AverageCenter)
                .Add("ZoomOnClick", this.ZoomOnClick, true)
                .Add("HideSingleGroupMarker", this.HideSingleGroupMarker)
                .Add("CustomStyles", customStyles, () => this.CustomStyles.Any());

            return result;
        }
    }
}