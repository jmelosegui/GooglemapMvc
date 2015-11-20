using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class Shape2DBuilder<TShape2D> : ShapeBuilder<TShape2D> where TShape2D : Shape2D
    {
        protected Shape2DBuilder(TShape2D shape2D) : base(shape2D)
        {
        }

        public Shape2DBuilder<TShape2D> FillColor(Color value)
        {
            Shape.FillColor = value;
            return this;
        }

        public Shape2DBuilder<TShape2D> FillOpacity(double value)
        {
            Shape.FillOpacity = value;
            return this;
        }
    }
}
