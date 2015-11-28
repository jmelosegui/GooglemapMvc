// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MapTypeStyleFactory : IHideObjectMembers
    {
        private readonly StyledMapType mapType;

        public MapTypeStyleFactory(StyledMapType mapType)
        {
            this.mapType = mapType;
        }

        public MapTypeStyleBuilder Add()
        {
            var style = new MapTypeStyle();

            this.mapType.Styles.Add(style);

            return new MapTypeStyleBuilder(style);
        }
    }
}