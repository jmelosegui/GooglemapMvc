// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    public class InfoWindow : Overlay
    {
        private readonly Marker marker;

        public InfoWindow(Marker marker)
            : base(PassThroughNonNull(marker).Map)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker));
            }

            this.marker = marker;
            this.Content = string.Format(CultureInfo.InvariantCulture, "{0}Marker{1}", marker.Map.Id, marker.Index);

            this.Template = new HtmlTemplate();
        }

        [JsonIgnore]
        public HtmlTemplate Template
        {
            get;
            private set;
        }

        public string Content { get; private set; }

        public bool DisableAutoPan { get; set; }

        public bool OpenOnRightClick { get; set; }

        public override double? Longitude
        {
            get
            {
                if (this.marker != null)
                {
                    return this.marker.Longitude;
                }

                return base.Longitude;
            }

            set
            {
                base.Longitude = value;
            }
        }

        public override double? Latitude
        {
            get
            {
                if (this.marker != null)
                {
                    return this.marker.Latitude;
                }

                return base.Latitude;
            }

            set
            {
                base.Latitude = value;
            }
        }

        public int MaxWidth { get; set; }

        public int ZIndex { get; set; }

        private static Marker PassThroughNonNull(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker));
            }

            return marker;
        }
    }
}