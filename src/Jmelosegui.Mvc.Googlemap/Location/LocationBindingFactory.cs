using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class LocationBindingFactory<TILocationContainer> where TILocationContainer : ILocationContainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public LocationBindingFactory<TILocationContainer> For<TDataItem>(Action<LocationBindingBuilder<TILocationContainer, TDataItem>> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            Binder = new LocationBinding<TILocationContainer, TDataItem>();
            var builder = new LocationBindingBuilder<TILocationContainer, TDataItem>((LocationBinding<TILocationContainer, TDataItem>)Binder);
            action(builder);

            return this;
        }

        public ILocationBinding<TILocationContainer> Binder { get; private set; }
    }
}