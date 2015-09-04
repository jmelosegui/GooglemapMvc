using System;
using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
{
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
                .Add("altName", mapType.MapTypeAltName, () => !String.IsNullOrEmpty(mapType.MapTypeAltName))
                .Add("name", mapType.MapTypeName)
                .Add("maxZoom", mapType.MaxZoom, 0)
                .Add("minZoom", mapType.MinZoom, 0)
                .Add("opacity", (mapType.Opacity / 100F), 1F)
                .Add("radius", mapType.Radius, 6378137);

            return result;
        }
    }
}
