using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class Shape : MapObject
    {
        protected Shape(Map map) : base(map)
        {
            strokeOpacity = 0.8D;
            StrokeWeight = 2;
            StrokeColor = Color.DarkRed;
            ZIndex = 1;
            Clickable = true;
        }

        public bool Clickable { get; set; }
        
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

        public int ZIndex { get; set; }

        public abstract ISerializer CreateSerializer();
    }
}
