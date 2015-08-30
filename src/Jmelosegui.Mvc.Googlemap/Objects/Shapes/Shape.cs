using System;
using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public abstract class Shape : MapObject
    {
        protected Shape(GoogleMap map) : base(map)
        {
            fillOpacity = 0.5D;
            strokeOpacity = 0.8D;
            StrokeWeight = 2;
            FillColor = Color.Red;
            StrokeColor = Color.DarkRed;
            zIndex = 1;
            Clickable = true;
        }

        public bool Clickable { get; set; }

        public Color FillColor { get; set; }

        private double fillOpacity;
        public double FillOpacity
        {
            get { return fillOpacity; }

            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("value", "The fill opacity between 0.0 and 1.0");
                fillOpacity = value;
            }
        }

        public Color StrokeColor { get; set; }

        private double strokeOpacity;
        public double StrokeOpacity
        {
            get { return strokeOpacity; }

            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("value", "The stroke opacity between 0.0 and 1.0");
                strokeOpacity = value;
            }
        }

        public int StrokeWeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "z")]
        public int zIndex { get; set; }

        public abstract ISerializer CreateSerializer();
    }
}
