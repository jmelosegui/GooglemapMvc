using System;
using Jmelosegui.Mvc.Googlemap.Objects.Layers;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class KmlLayerBuilder : LayerBuilder<KmlLayer>
    {
        #region Constructor
        internal KmlLayerBuilder(KmlLayer kmlLayer)
            : base(kmlLayer)
        {

        } 
        #endregion

        #region Public Methods
        public KmlLayerBuilder Clickable(bool value)
        {
            Layer.Clickable = value;

            return this;
        }

        public KmlLayerBuilder PreserveViewport(bool value)
        {
            Layer.PreserveViewport = value;

            return this;
        }

        public KmlLayerBuilder ScreenOverlays(bool value)
        {
            Layer.ScreenOverlays = value;
            return this;
        }

        public KmlLayerBuilder SuppressInfoWindows(bool value)
        {
            Layer.SuppressInfoWindows = value;
            return this;
        }

        public KmlLayerBuilder Url(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(url, "Url cannot be null");
            Layer.Url = url.ToAbsoluteUrl();
            
            return this;
        }

        public KmlLayerBuilder zIndex(int value)
        {
            Layer.zIndex = value;
            return this;
        } 
        #endregion
    }
}