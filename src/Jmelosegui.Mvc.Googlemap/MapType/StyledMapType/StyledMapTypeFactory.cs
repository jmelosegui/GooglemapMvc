// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class StyledMapTypeFactory : IHideObjectMembers
    {
        public StyledMapTypeFactory(Map map)
        {
            this.Map = map;
        }

        protected Map Map { get; private set; }

        public StyledMapTypeBuilder Add()
        {
            var maptype = new StyledMapType();

            this.Map.StyledMapTypes.Add(maptype);

            return new StyledMapTypeBuilder(maptype);
        }
    }
}