// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;

    public class Polygon : Shape2D, ILocationContainer
    {
        private readonly List<Location> points;

        public Polygon(Map map)
            : base(map)
        {
            this.points = new List<Location>();
        }

        public IList<Location> Points
        {
            get
            {
                return this.points.AsReadOnly();
            }
        }

        public virtual void AddPoint(Location point)
        {
            this.points.Add(point);
        }

        public override ISerializer CreateSerializer()
        {
            return new PolygonSerializer(this);
        }
    }
}