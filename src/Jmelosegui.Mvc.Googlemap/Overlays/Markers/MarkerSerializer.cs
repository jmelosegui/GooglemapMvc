using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
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

            if (marker.Window != null)
            {
                FluentDictionary.For(windowDictionary)
                .Add("content", marker.Window.Content)
                .Add("disableAutoPan", marker.Window.DisableAutoPan, () => marker.Window.DisableAutoPan)
                .Add("lat", marker.Window.Latitude, () => marker.Latitude != marker.Window.Latitude)
                .Add("lng", marker.Window.Longitude, () => marker.Longitude != marker.Window.Longitude)
                .Add("maxWidth", marker.Window.MaxWidth, () => marker.Window.MaxWidth != 0)
                .Add("zIndex", marker.Window.zIndex, () => marker.Window.zIndex != 0); 
            }

            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("id", marker.Id, () => marker.Id != null)
                .Add("title", marker.Title, () => marker.Title != null)
                .Add("lat", marker.Latitude, () => marker.Latitude != null)
                .Add("lng", marker.Longitude, () => marker.Latitude != null)
                .Add("zIndex", marker.zIndex, 0)
                .Add("clickable", marker.Clickable, true)
                .Add("draggable", marker.Draggable, false)
                .Add("icon", marker.Icon, () => marker.Icon != null)
                .Add("window", windowDictionary, () => marker.Window != null);

            return result;
        }
    }
}
