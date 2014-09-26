using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerClusteringStylesSerializer : IOverlaySerializer
    {
        private readonly MarkerClusteringStyles style;

        public MarkerClusteringStylesSerializer(MarkerClusteringStyles style)
        {
            this.style = style;
        }

        #region IOverlaySerializer Members

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            result["url"] = style.Url;
            result["height"] = style.Height;
            result["width"] = style.Width;
            result["textSize"] = style.TextSize;
            result["textColor"] = style.TextColor.ToHtml();

            return result;
        }

        #endregion
    }
}