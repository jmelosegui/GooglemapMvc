using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class LocationBindingBuilder<TLocationContainer, TDataItem> where TLocationContainer : ILocationContainer
    {
        readonly LocationBinding<TLocationContainer, TDataItem> locationBinding;

        public LocationBindingBuilder(LocationBinding<TLocationContainer, TDataItem> locationBinding)
        {
            this.locationBinding = locationBinding;
        }

        public LocationBindingBuilder<TLocationContainer, TDataItem> ItemDataBound(Action<TLocationContainer, TDataItem> action)
        {
            locationBinding.ItemDataBound = action;
            return this;
        }
    }
}
