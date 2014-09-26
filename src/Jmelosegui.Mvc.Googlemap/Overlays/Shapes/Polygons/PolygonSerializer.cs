using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class PolygonSerializer : ShapeSerializer<Polygon>
    {
        private readonly Polygon polygon;
        public PolygonSerializer(Polygon polygon) : base(polygon)
        {
            this.polygon = polygon;
        }

        public override IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = base.Serialize();
            result.Add("Points", polygon.Points);
            return result;
        }
    }
}
