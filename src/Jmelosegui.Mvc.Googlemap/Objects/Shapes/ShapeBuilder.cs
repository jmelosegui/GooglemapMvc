using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class ShapeBuilder<TShape> where TShape : Shape
    {
        protected ShapeBuilder(ShapeBuilder<TShape> builder)
            : this(builder.Shape)
        {
        }

        public ShapeBuilder(TShape shape)
        {
            this.Shape = shape;
        }

        protected TShape Shape { get; private set; }

        public ShapeBuilder<TShape> Clickable(bool enabled)
        {
            Shape.Clickable = enabled;
            return this; 
        }

        public ShapeBuilder<TShape> FillColor(Color value)
        {
            Shape.FillColor = value;
            return this;
        }

        public ShapeBuilder<TShape> FillOpacity(double value)
        {
            Shape.FillOpacity = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeColor(Color value)
        {
            Shape.StrokeColor = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeOpacity(double value)
        {
            Shape.StrokeOpacity = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeWeight(int value)
        {
            Shape.StrokeWeight = value;
            return this;
        }

        public ShapeBuilder<TShape> zIndex(int value)
        {
            Shape.zIndex = value;
            return this;
        }
    }
}
