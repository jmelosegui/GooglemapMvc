// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class StyledMapTypeBuilder : MapTypeBuilder<StyledMapType>
    {
        public StyledMapTypeBuilder(StyledMapType mapType)
            : base(mapType)
        {
        }

        public StyledMapTypeBuilder Styles(Action<MapTypeStyleFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new MapTypeStyleFactory(this.MapType);
            action(factory);
            return this;
        }
    }
}