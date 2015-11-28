// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class MapTypeSerializer : ISerializer
    {
        private readonly MapTypeBase mapType;

        public MapTypeSerializer(MapTypeBase mapType)
        {
            this.mapType = mapType;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("altName", this.mapType.MapTypeAltName, () => !string.IsNullOrEmpty(this.mapType.MapTypeAltName))
                .Add("name", this.mapType.MapTypeName)
                .Add("maxZoom", this.mapType.MaxZoom, 0)
                .Add("minZoom", this.mapType.MinZoom, 0)
                .Add("opacity", this.mapType.Opacity / 100F, 1F)
                .Add("radius", this.mapType.Radius, 6378137);

            return result;
        }
    }
}
