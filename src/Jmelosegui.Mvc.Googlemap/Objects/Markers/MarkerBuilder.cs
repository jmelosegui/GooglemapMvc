// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class MarkerBuilder
    {
        public MarkerBuilder(Marker marker)
        {
            this.Marker = marker;
        }

        protected MarkerBuilder(MarkerBuilder builder)
            : this(PassThroughNonNull(builder).Marker)
        {
        }

        protected Marker Marker { get; private set; }

        public MarkerBuilder Address(string value)
        {
            this.Marker.Address = value;
            return this;
        }

        public MarkerBuilder Id(string markerId)
        {
            this.Marker.Id = markerId;
            return this;
        }

        public MarkerBuilder Clickable(bool enabled)
        {
            this.Marker.Clickable = enabled;
            return this;
        }

        public MarkerBuilder Draggable(bool enabled)
        {
            this.Marker.Draggable = enabled;
            return this;
        }

        public MarkerBuilder Icon(Uri absoluteUrl)
        {
            Size size = new Size(32, 32);
            return this.Icon(absoluteUrl, size);
        }

        public MarkerBuilder Icon(Uri absoluteUrl, Size size)
        {
            Point point = new Point(0, 0);
            Point anchor = new Point(size.Width / 2, size.Height);

            return this.Icon(absoluteUrl, size, point, anchor);
        }

        public MarkerBuilder Icon(Uri absoluteUrl, Size size, Point point, Point anchor)
        {
            this.Marker.Icon = new MarkerImage(absoluteUrl, size, point, anchor);
            return this;
        }

        public MarkerBuilder Latitude(double value)
        {
            this.Marker.Latitude = value;
            return this;
        }

        public MarkerBuilder Longitude(double value)
        {
            this.Marker.Longitude = value;
            return this;
        }

        public MarkerBuilder Title(string value)
        {
            this.Marker.Title = value;
            return this;
        }

        public MarkerBuilder Window(Action<InfoWindowFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new InfoWindowFactory(this.Marker);
            action(factory);
            return this;
        }

        public MarkerBuilder ZIndex(int value)
        {
            this.Marker.ZIndex = value;
            return this;
        }

        private static MarkerBuilder PassThroughNonNull(MarkerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
