// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public abstract class MapObject
    {
        protected MapObject(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            this.Map = map;
        }

        protected internal Map Map { get; private set; }
    }
}