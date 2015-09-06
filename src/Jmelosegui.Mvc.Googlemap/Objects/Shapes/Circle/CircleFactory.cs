namespace Jmelosegui.Mvc.GoogleMap
{
    public class CircleFactory : IHideObjectMembers
    {
        public CircleFactory(Map map)
        {
            this.Map = map;
        }

        protected Map Map { get; private set; }

        public CircleBuilder Add()
        {
            var circle = new Circle(Map);

            Map.Circles.Add(circle);

            return new CircleBuilder(circle);
        }
    }
}
