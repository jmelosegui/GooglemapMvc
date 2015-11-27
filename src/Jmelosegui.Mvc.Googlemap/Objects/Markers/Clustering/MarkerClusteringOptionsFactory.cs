// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MarkerClusteringOptionsFactory : MapObject
    {
        public MarkerClusteringOptionsFactory(Map component)
            : base(component)
        {
        }

        public int MaxZoom
        {
            get
            {
                return this.Map.MarkerClusteringOptions.MaxZoom;
            }

            set
            {
                this.Map.MarkerClusteringOptions.MaxZoom = value;
            }
        }

        public int GridSize
        {
            get
            {
                return this.Map.MarkerClusteringOptions.GridSize;
            }

            set
            {
                this.Map.MarkerClusteringOptions.GridSize = value;
            }
        }

        public bool AverageCenter
        {
            get
            {
                return this.Map.MarkerClusteringOptions.AverageCenter;
            }

            set
            {
                this.Map.MarkerClusteringOptions.AverageCenter = value;
            }
        }

        public bool ZoomOnClick
        {
            get
            {
                return this.Map.MarkerClusteringOptions.ZoomOnClick;
            }

            set
            {
                this.Map.MarkerClusteringOptions.ZoomOnClick = value;
            }
        }

        public bool HideSingleGroupMarker
        {
            get
            {
                return this.Map.MarkerClusteringOptions.HideSingleGroupMarker;
            }

            set
            {
                this.Map.MarkerClusteringOptions.HideSingleGroupMarker = value;
            }
        }

        public void CustomStyles(Action<MarkerClusteringStylesFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new MarkerClusteringStylesFactory(this.Map);
            action(factory);
        }
    }
}
