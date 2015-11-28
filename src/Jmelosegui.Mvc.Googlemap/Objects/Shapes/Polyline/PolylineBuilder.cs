// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class PolylineBuilder : ShapeBuilder<Polyline>
    {
        public PolylineBuilder(Polyline shape)
            : base(shape)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public virtual PolylineBuilder Points(Action<LocationFactory<Polyline>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new LocationFactory<Polyline>(this.Shape);
            action(factory);
            return this;
        }
    }
}
