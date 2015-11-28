// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MapObjectBindingBuilder<TMapObject, TDataItem>
        where TMapObject : MapObject
    {
        private readonly MapObjectBinding<TMapObject, TDataItem> bindingComponent;

        public MapObjectBindingBuilder(MapObjectBinding<TMapObject, TDataItem> mapObjectBinding)
        {
            this.bindingComponent = mapObjectBinding;
        }

        public MapObjectBindingBuilder<TMapObject, TDataItem> ItemDataBound(Action<TMapObject, TDataItem> action)
        {
            this.bindingComponent.ItemDataBound = action;
            return this;
        }
    }
}