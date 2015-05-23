using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class LocationBinding<TLocationContainer, TDataItem> : ILocationBinding<TLocationContainer> where TLocationContainer : ILocationContainer
    {
        public Action<TLocationContainer, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void ILocationBinding<TLocationContainer>.ItemDataBound(TLocationContainer item, object value)
        {
            ItemDataBound(item, (TDataItem)value);
        }
    }
}