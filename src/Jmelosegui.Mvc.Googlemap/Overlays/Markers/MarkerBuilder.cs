using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Web.Optimization;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerBuilder
    {
        private readonly Marker marker;

        public MarkerBuilder(Marker marker)
        {
            this.marker = marker;
        }

        public MarkerBuilder Clickable(bool enabled)
        {
            marker.Clickable = enabled;
            return this;
        }

        public MarkerBuilder Draggable(bool enabled)
        {
            marker.Draggable = enabled;
            return this;
        }

        public MarkerBuilder Icon(string path, Size size, Point point, Point anchor)
        {
            marker.Icon = new MarkerImage(path, size, point, anchor); 
            return this;
        }

        public MarkerBuilder Latitude(double value)
        {
            marker.Latitude = value;
            return this;
        }

        public MarkerBuilder Longitude(double value)
        {
            marker.Longitude = value;
            return this;
        }

        public MarkerBuilder Title(string value)
        {
            marker.Title = value;
            return this;
        }

        public MarkerBuilder Window(Action<InfoWindowFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            
            var factory = new InfoWindowFactory(marker);
            action(factory);
            return this;
        }

        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "z")]
        public MarkerBuilder zIndex(int value)
        {
            marker.zIndex = value;
            return this;
        }
    }
}
