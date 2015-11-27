// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class LocationBindingFactory<TILocationContainer>
        where TILocationContainer : ILocationContainer
    {
        public ILocationBinding<TILocationContainer> Binder { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public LocationBindingFactory<TILocationContainer> For<TDataItem>(Action<LocationBindingBuilder<TILocationContainer, TDataItem>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.Binder = new LocationBinding<TILocationContainer, TDataItem>();
            var builder = new LocationBindingBuilder<TILocationContainer, TDataItem>((LocationBinding<TILocationContainer, TDataItem>)this.Binder);
            action(builder);

            return this;
        }
    }
}