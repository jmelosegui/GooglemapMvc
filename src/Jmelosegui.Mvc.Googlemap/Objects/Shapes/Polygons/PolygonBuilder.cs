using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class PolygonBuilder : ShapeBuilder<Polygon>
    {
        public PolygonBuilder(Polygon shape) : base(shape)
        {
        }

        public virtual ShapeBuilder<Polygon> Points(Action<LocationFactory<Polygon>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<Polygon>(base.Shape);
            action(factory);
            return this;
        }
    }
}
