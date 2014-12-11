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
            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("title", marker.Title, () => marker.Title != null)
                .Add("lat", marker.Latitude, () => marker.Latitude != null)
                .Add("lng", marker.Longitude, () => marker.Latitude != null)
                .Add("zIndex", marker.zIndex, 0)
                .Add("clickable", marker.Clickable, true)
                .Add("draggable", marker.Draggable, false)
                .Add("icon", marker.Icon, () => marker.Icon != null)
                .Add("window", marker.Window, () => marker.Window != null);

            return result;
        }
    }
}
