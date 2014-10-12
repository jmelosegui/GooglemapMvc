using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeSerializer : ISerializer
    {
        private readonly MapType mapType;

        public MapTypeSerializer(MapType mapType)
        {
            this.mapType = mapType;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (mapType.MapTypeAltName != null)
                result["altName"] = mapType.MapTypeAltName;
            result["name"] = mapType.MapTypeName;
            result["maxZoom"] = mapType.MaxZoom;
            result["minZoom"] = mapType.MinZoom;
            result["opacity"] = (mapType.Opacity / 100F);
            result["radius"] = mapType.Radius;

            return result;
        }
    }
}
