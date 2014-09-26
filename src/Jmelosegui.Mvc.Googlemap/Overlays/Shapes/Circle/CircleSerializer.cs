using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class CircleSerializer : ShapeSerializer<Circle>
    {
        private readonly Circle circle;

        public CircleSerializer(Circle circle) : base(circle)
        {
            this.circle = circle;
        }

        public override IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = base.Serialize();

            result["Center"] = circle.Center;
            result["Radius"] = circle.Radius;

            return result;
        }
    }
}