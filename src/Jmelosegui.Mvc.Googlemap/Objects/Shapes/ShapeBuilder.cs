using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class ShapeBuilder<TShape> where TShape : Shape
    {
        protected ShapeBuilder(ShapeBuilder<TShape> builder) : this(PassThroughNonNull(builder).Shape)
        {
        }

        protected ShapeBuilder(TShape shape)
        {
            Shape = shape;
        }

        protected TShape Shape { get; private set; }

        public ShapeBuilder<TShape> Clickable(bool enabled)
        {
            Shape.Clickable = enabled;
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

        public ShapeBuilder<TShape> ZIndex(int value)
        {
            Shape.ZIndex = value;
            return this;
        }

        private static ShapeBuilder<TShape> PassThroughNonNull(ShapeBuilder<TShape> builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}
