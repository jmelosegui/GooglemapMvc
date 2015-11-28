// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MapObjectBindingFactory<TMapObject>
        where TMapObject : MapObject
    {
        public IMapObjectBinding<TMapObject> Binder { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public MapObjectBindingFactory<TMapObject> For<TDataItem>(Action<MapObjectBindingBuilder<TMapObject, TDataItem>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.Binder = new MapObjectBinding<TMapObject, TDataItem>();
            var builder = new MapObjectBindingBuilder<TMapObject, TDataItem>((MapObjectBinding<TMapObject, TDataItem>)this.Binder);
            action(builder);

            return this;
        }
    }
}
