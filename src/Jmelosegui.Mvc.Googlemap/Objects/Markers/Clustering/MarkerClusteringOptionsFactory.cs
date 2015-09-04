using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringOptionsFactory : MapObject
    {
        public MarkerClusteringOptionsFactory(Map component) : base(component)
        {
        }

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

        public void CustomStyles(Action<MarkerClusteringStylesFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new MarkerClusteringStylesFactory(Map);
            action(factory);
        }

        //public Collection<MarkerClusteringStyles> CustomStyles
        //{
        //    get { return Map.MarkerClusteringOptions.CustomStyles; }

        //}
    }
}
