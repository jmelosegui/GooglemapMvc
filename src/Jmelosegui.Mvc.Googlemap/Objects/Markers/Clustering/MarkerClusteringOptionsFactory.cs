using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerClusteringOptionsFactory
    {
        private readonly GoogleMap map;

        public MarkerClusteringOptionsFactory(GoogleMap component)
        {
            this.map = component;
        }

        public int MaxZoom
        {
            get
            {
                return map.MarkerClusteringOptions.MaxZoom;
            }
            set 
            {
                map.MarkerClusteringOptions.MaxZoom = value;
            }
        }

        public int GridSize 
        {
            get
            {
                return map.MarkerClusteringOptions.GridSize;
            }
            set
            {
                map.MarkerClusteringOptions.GridSize = value;
            }
        }

        public bool AverageCenter
        {
            get
            {
                return map.MarkerClusteringOptions.AverageCenter;
            }
            set
            {
                map.MarkerClusteringOptions.AverageCenter = value;
            }
        }

        public bool ZoomOnClick
        {
            get
            {
                return map.MarkerClusteringOptions.ZoomOnClick;
            }
            set
            {
                map.MarkerClusteringOptions.ZoomOnClick = value;
            }
        }

        public bool HideSingleGroupMarker
        {
            get
            {
                return map.MarkerClusteringOptions.HideSingleGroupMarker;
            }
            set
            {
                map.MarkerClusteringOptions.HideSingleGroupMarker = value;
            }
        }

        public List<MarkerClusteringStyles> CustomStyles
        {
            get { return map.MarkerClusteringOptions.CustomStyles; }
            
        }
    }
}
