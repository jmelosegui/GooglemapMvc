using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class KmlLayerBuilder
    {
        private readonly KmlLayer kmlLayer;

        internal KmlLayerBuilder(KmlLayer kmlLayer)
        {
            if (kmlLayer == null) throw new ArgumentNullException("kmlLayer");

            this.kmlLayer = kmlLayer;
        }

        public KmlLayerBuilder Clickable(bool value)
        {
            kmlLayer.Clickable = value;

            return this;
        }
        public KmlLayerBuilder PreserveViewport(bool value)
        {
            kmlLayer.PreserveViewport = value;

            return this;
        }

        public KmlLayerBuilder ScreenOverlays(bool value)
        {
            kmlLayer.ScreenOverlays = value;
            return this;
        }

        public KmlLayerBuilder SuppressInfoWindows(bool value)
        {
            kmlLayer.SuppressInfoWindows = value;
            return this;
        }

        public KmlLayerBuilder Url(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(url, "Url cannot be null");

            if (url.IndexOf("://", StringComparison.Ordinal) == -1)
            {
                kmlLayer.Url = System.Web.VirtualPathUtility.ToAbsolute(url);
            }
            else
            {
                kmlLayer.Url = url;
            }

            return this;
        }

        public KmlLayerBuilder zIndex(int value)
        {
            kmlLayer.zIndex = value;
            return this;
        }
    }
}