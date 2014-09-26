using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerSerializer : IOverlaySerializer
    {
        private readonly Marker marker;

        public MarkerSerializer(Marker marker)
        {
            this.marker = marker;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (marker.Title != null)
                result["Title"] = marker.Title;
            result["Latitude"] = marker.Latitude;
            result["Longitude"] = marker.Longitude;
            result["zIndex"] = marker.zIndex;
            if (marker.Clickable)
                result["Clickable"] = marker.Clickable;
            if (marker.Draggable)
                result["Draggable"] = marker.Draggable;
            if (marker.Icon != null)
                result["Icon"] = marker.Icon;
            if (marker.Window != null)
                result["Window"] = marker.Window;
                

            return result;
        }
    }
}
