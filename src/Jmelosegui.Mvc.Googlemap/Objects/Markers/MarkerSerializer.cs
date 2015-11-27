// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class MarkerSerializer : ISerializer
    {
        private readonly Marker marker;

        public MarkerSerializer(Marker marker)
        {
            this.marker = marker;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> windowDictionary = new Dictionary<string, object>();

            if (this.marker.Window != null)
            {
                FluentDictionary.For(windowDictionary)
                .Add("content", this.marker.Window.Content)
                .Add("disableAutoPan", this.marker.Window.DisableAutoPan, () => this.marker.Window.DisableAutoPan)
                .Add("openOnRightClick", this.marker.Window.OpenOnRightClick, () => this.marker.Window.OpenOnRightClick)
                .Add("lat", this.marker.Window.Latitude, () => this.marker.Latitude != this.marker.Window.Latitude)
                .Add("lng", this.marker.Window.Longitude, () => this.marker.Longitude != this.marker.Window.Longitude)
                .Add("maxWidth", this.marker.Window.MaxWidth, () => this.marker.Window.MaxWidth != 0)
                .Add("zIndex", this.marker.Window.ZIndex, () => this.marker.Window.ZIndex != 0);
            }

            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("id", this.marker.Id, () => this.marker.Id != null)
                .Add("address", this.marker.Address, () => this.marker.Address != null)
                .Add("title", this.marker.Title, () => this.marker.Title != null)
                .Add("lat", this.marker.Latitude, () => this.marker.Latitude != null)
                .Add("lng", this.marker.Longitude, () => this.marker.Latitude != null)
                .Add("zIndex", this.marker.ZIndex, 0)
                .Add("clickable", this.marker.Clickable, true)
                .Add("draggable", this.marker.Draggable, false)
                .Add("icon", this.marker.Icon, () => this.marker.Icon != null)
                .Add("window", windowDictionary, () => this.marker.Window != null);

            return result;
        }
    }
}
