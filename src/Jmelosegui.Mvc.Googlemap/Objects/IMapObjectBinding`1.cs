// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public interface IMapObjectBinding<in TMapObject>
        where TMapObject : MapObject
    {
        void ItemDataBound(TMapObject item, object value);
    }

    public sealed class MapObjectBinding<TMapObject, TDataItem> : IMapObjectBinding<TMapObject>
        where TMapObject : MapObject
    {
        public Action<TMapObject, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void IMapObjectBinding<TMapObject>.ItemDataBound(TMapObject item, object value)
        {
            this.ItemDataBound(item, (TDataItem)value);
        }
    }
}
