using System;
using System.ComponentModel;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class PolylineBuilder : ShapeBuilder<Polyline>
    {
        public PolylineBuilder(Polyline shape) : base(shape)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public virtual PolylineBuilder Points(Action<LocationFactory<Polyline>> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LocationFactory<Polyline>(base.Shape);
            action(factory);
            return this;
        }
    }
}
