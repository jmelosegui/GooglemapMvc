namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class CircleBuilder : ShapeBuilder<Circle>
    {
        public CircleBuilder(Circle shape) : base(shape)
        {
        }

        public CircleBuilder Center(Location point)
        {
            Shape.Center = point;
            return this;
        }

        public CircleBuilder Radius(int value)
        {
            Shape.Radius = value;
            return this;
        }
    }
}
