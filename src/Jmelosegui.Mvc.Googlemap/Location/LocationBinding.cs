// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public sealed class LocationBinding<TLocationContainer, TDataItem> : ILocationBinding<TLocationContainer>
        where TLocationContainer : ILocationContainer
    {
        public Action<TLocationContainer, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void ILocationBinding<TLocationContainer>.ItemDataBound(TLocationContainer item, object value)
        {
            this.ItemDataBound(item, (TDataItem)value);
        }
    }
}