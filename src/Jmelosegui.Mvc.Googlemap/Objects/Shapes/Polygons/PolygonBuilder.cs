using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class PolygonBuilder : Shape2DBuilder<Polygon>
    {
        public PolygonBuilder(Polygon shape) : base(shape)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public virtual PolygonBuilder Points(Action<LocationFactory<Polygon>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<Polygon>(Shape);
            action(factory);
            return this;
        }
    }
}
