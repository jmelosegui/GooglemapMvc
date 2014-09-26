namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class CircleFactory : IHideObjectMembers
    {
        private readonly GoogleMap map;

        public CircleFactory(GoogleMap map)
        {
            this.map = map;
        }

        public CircleBuilder Add()
        {
            var circle = new Circle(map);

            map.Circles.Add(circle);

            return new CircleBuilder(circle);
        }
    }
}
