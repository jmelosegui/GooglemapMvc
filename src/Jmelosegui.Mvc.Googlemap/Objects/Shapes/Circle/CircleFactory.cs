namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class CircleFactory : IHideObjectMembers
    {
        public CircleFactory(GoogleMap map)
        {
            this.Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public CircleBuilder Add()
        {
            var circle = new Circle(Map);

            Map.Circles.Add(circle);

            return new CircleBuilder(circle);
        }
    }
}
