using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class LocationBindingBuilder<TLocationContainer, TDataItem> where TLocationContainer : ILocationContainer
    {
        readonly LocationBinding<TLocationContainer, TDataItem> bindingComponent;

        public LocationBindingBuilder(LocationBinding<TLocationContainer, TDataItem> overlayBinding)
        {
            bindingComponent = overlayBinding;
        }

        public LocationBindingBuilder<TLocationContainer, TDataItem> ItemDataBound(Action<TLocationContainer, TDataItem> action)
        {
            bindingComponent.ItemDataBound = action;
            return this;
        }
    }
}
