using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerClusteringOptionsFactory
    {
        public MarkerClusteringOptionsFactory(GoogleMap component)
        {
            this.Map = component;
        }

        protected GoogleMap Map { get; private set; }

        public int MaxZoom
        {
            get
            {
                return Map.MarkerClusteringOptions.MaxZoom;
            }
            set 
            {
                Map.MarkerClusteringOptions.MaxZoom = value;
            }
        }

        public int GridSize 
        {
            get
            {
                return Map.MarkerClusteringOptions.GridSize;
            }
            set
            {
                Map.MarkerClusteringOptions.GridSize = value;
            }
        }

        public bool AverageCenter
        {
            get
            {
                return Map.MarkerClusteringOptions.AverageCenter;
            }
            set
            {
                Map.MarkerClusteringOptions.AverageCenter = value;
            }
        }

        public bool ZoomOnClick
        {
            get
            {
                return Map.MarkerClusteringOptions.ZoomOnClick;
            }
            set
            {
                Map.MarkerClusteringOptions.ZoomOnClick = value;
            }
        }

        public bool HideSingleGroupMarker
        {
            get
            {
                return Map.MarkerClusteringOptions.HideSingleGroupMarker;
            }
            set
            {
                Map.MarkerClusteringOptions.HideSingleGroupMarker = value;
            }
        }

        public List<MarkerClusteringStyles> CustomStyles
        {
            get { return Map.MarkerClusteringOptions.CustomStyles; }
            
        }
    }
}
