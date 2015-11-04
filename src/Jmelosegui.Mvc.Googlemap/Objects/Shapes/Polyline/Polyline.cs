using System;
using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class Polyline : Shape, ILocationContainer
    {
        private readonly List<Location> points;

        public Polyline(Map map) : base(map)
        {
            points = new List<Location>();
        }

        public IList<Location> Points
        {
            get { return points.AsReadOnly(); }
        }

        public virtual void AddPoint(Location point)
        {
            if (point == null) throw new ArgumentNullException("point");
            points.Add(point);
        }

        public override ISerializer CreateSerializer()
        {
            return new PolylineSerializer(this);
        }
    }
}