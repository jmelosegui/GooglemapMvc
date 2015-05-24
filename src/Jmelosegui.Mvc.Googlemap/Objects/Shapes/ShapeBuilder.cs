using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class ShapeBuilder<TShape> where TShape : Shape
    {
        private readonly TShape shape;

        public ShapeBuilder(TShape shape)
        {
            this.shape = shape;
        }

        public ShapeBuilder<TShape> Clickable(bool enabled)
        {
            shape.Clickable = enabled;
            return this; 
        }

        public ShapeBuilder<TShape> FillColor(Color value)
        {
            shape.FillColor = value;
            return this;
        }

        public ShapeBuilder<TShape> FillOpacity(double value)
        {
            shape.FillOpacity = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeColor(Color value)
        {
            shape.StrokeColor = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeOpacity(double value)
        {
            shape.StrokeOpacity = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeWeight(int value)
        {
            shape.StrokeWeight = value;
            return this;
        }

        public ShapeBuilder<TShape> zIndex(int value)
        {
            shape.zIndex = value;
            return this;
        }
    }
}
