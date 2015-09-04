using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class KmlLayerBuilder : LayerBuilder<KmlLayer>
    {
        #region Constructor
        internal KmlLayerBuilder(KmlLayer kmlLayer) : base(kmlLayer)
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Could be a virtual Url")]
        public KmlLayerBuilder Url(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(value, "Url cannot be null");
            Layer.Url = new Uri(value.ToAbsoluteUrl());
            
            return this;
        }

        public KmlLayerBuilder ZIndex(int value)
        {
            Layer.ZIndex = value;
            return this;
        } 
        #endregion
    }
}