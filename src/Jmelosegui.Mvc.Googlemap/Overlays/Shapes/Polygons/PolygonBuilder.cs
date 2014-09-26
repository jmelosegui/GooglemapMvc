using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class PolygonBuilder : ShapeBuilder<Polygon>
    {
        private readonly Polygon polygon;

        public PolygonBuilder(Polygon polygon): base(polygon)
        {
            this.polygon = polygon;
        }

        public virtual ShapeBuilder<Polygon> Points(Action<LocationFactory<Polygon>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<Polygon>(polygon);
            action(factory);
            return this;
        }
    }
}
