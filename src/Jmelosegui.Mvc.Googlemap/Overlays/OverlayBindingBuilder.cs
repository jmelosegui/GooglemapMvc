using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class OverlayBindingBuilder<TGoogleMapOverlay, TDataItem> where TGoogleMapOverlay : Overlay
    {
        readonly OverlayBinding<TGoogleMapOverlay, TDataItem> bindingComponent;

        public OverlayBindingBuilder(OverlayBinding<TGoogleMapOverlay, TDataItem> overlayBinding)
        {
            bindingComponent = overlayBinding;
        }

        public OverlayBindingBuilder<TGoogleMapOverlay, TDataItem> ItemDataBound(Action<TGoogleMapOverlay, TDataItem> action)
        {
            bindingComponent.ItemDataBound = action;
            return this;
        }
    }

}