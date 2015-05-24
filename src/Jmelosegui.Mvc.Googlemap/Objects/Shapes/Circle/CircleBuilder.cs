namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class CircleBuilder : ShapeBuilder<Circle>
    {
        private readonly Circle shape;

        public CircleBuilder(Circle shape) : base(shape)
        {
            this.shape = shape;
        }

        public CircleBuilder Center(Location point)
        {
            shape.Center = point;
            return this;
        }

        public CircleBuilder Radius(int value)
        {
            shape.Radius = value;
            return this;
        }
    }
}
