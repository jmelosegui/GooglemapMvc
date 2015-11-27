// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class PolygonSerializer : ShapeSerializer<Polygon>
    {
        private readonly Polygon polygon;

        public PolygonSerializer(Polygon polygon)
            : base(polygon)
        {
            this.polygon = polygon;
        }

        public override IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = base.Serialize();

            result.Add("Points", this.polygon.Points);

            return result;
        }
    }
}
