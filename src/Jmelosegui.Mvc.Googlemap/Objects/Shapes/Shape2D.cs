using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class Shape2D : Shape
    {
        private double fillOpacity;

        protected Shape2D(Map map) : base(map)
        {
            fillOpacity = 0.5D;
            FillColor = Color.Red;
        }

        public Color FillColor { get; set; }

        public double FillOpacity
        {
            get { return fillOpacity; }

            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("value", "The fill opacity between 0.0 and 1.0");
                fillOpacity = value;
            }
        }
    }
}
