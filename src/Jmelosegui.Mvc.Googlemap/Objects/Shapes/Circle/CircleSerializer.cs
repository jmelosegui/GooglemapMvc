// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class CircleSerializer : ShapeSerializer<Circle>
    {
        private readonly Circle circle;

        public CircleSerializer(Circle circle)
            : base(circle)
        {
            this.circle = circle;
        }

        public override IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = base.Serialize();

            result["Center"] = this.circle.Center;
            result["Radius"] = this.circle.Radius;

            return result;
        }
    }
}