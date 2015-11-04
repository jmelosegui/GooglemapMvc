using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class PolylineSerializer : ShapeSerializer<Polyline>
    {
        private readonly Polyline polyline;

        public PolylineSerializer(Polyline polyline) : base(polyline)
        {
            this.polyline = polyline;
        }

        public override IDictionary<string, object> Serialize()
        {
            var result = base.Serialize();

            result.Add("Points", polyline.Points);

            return result;
        }
    }
}