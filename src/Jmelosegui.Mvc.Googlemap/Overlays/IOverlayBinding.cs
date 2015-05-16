using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class OverlayBinding<TGoogleMapOverlay, TDataItem> : IOverlayBinding<TGoogleMapOverlay> where TGoogleMapOverlay : Overlay
    {

        public Action<TGoogleMapOverlay, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void IOverlayBinding<TGoogleMapOverlay>.ItemDataBound(TGoogleMapOverlay item, object value)
        {
            ItemDataBound(item, (TDataItem)value);
        }

    }

    public interface IOverlayBinding<in TGoogleMapOverlay> where TGoogleMapOverlay : Overlay
    {
        void ItemDataBound(TGoogleMapOverlay item, object value);
    }
}
