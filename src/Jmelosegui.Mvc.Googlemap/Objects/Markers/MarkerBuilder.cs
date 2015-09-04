using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerBuilder
    {
        protected MarkerBuilder(MarkerBuilder builder)  : this(PassThroughNonNull(builder).Marker)
        {
            
        }

        public MarkerBuilder(Marker marker)
        {
            this.Marker = marker;
        }

        protected Marker Marker { get; private set; }

        public MarkerBuilder Address(string value)
        {
            Marker.Address = value;
            return this;
        }

        public MarkerBuilder Id(string markerId)
        {
            Marker.Id = markerId;
            return this;
        }

        public MarkerBuilder Clickable(bool enabled)
        {
            Marker.Clickable = enabled;
            return this;
        }

        public MarkerBuilder Draggable(bool enabled)
        {
            Marker.Draggable = enabled;
            return this;
        }

        public MarkerBuilder Icon(string path)
        {
            Size size = new Size(32, 32);
            return Icon(path, size);
        }

        public MarkerBuilder Icon(string path, Size size)
        {
            Point point = new Point(0,0);
            Point anchor = new Point(size.Width/2, size.Height);
            
            return Icon(path, size, point, anchor);
        }

        public MarkerBuilder Icon(string path, Size size, Point point, Point anchor)
        {
            Marker.Icon = new MarkerImage(path, size, point, anchor); 
            return this;
        }

        public MarkerBuilder Latitude(double value)
        {
            Marker.Latitude = value;
            return this;
        }

        public MarkerBuilder Longitude(double value)
        {
            Marker.Longitude = value;
            return this;
        }

        public MarkerBuilder Title(string value)
        {
            Marker.Title = value;
            return this;
        }

        public MarkerBuilder Window(Action<InfoWindowFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new InfoWindowFactory(Marker);
            action(factory);
            return this;
        }

        public MarkerBuilder ZIndex(int value)
        {
            Marker.ZIndex = value;
            return this;
        }

        private static MarkerBuilder PassThroughNonNull(MarkerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}
