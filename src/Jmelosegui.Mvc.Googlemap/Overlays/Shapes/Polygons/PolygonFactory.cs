namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class PolygonFactory : IHideObjectMembers
    {
        private readonly GoogleMap map;

        public PolygonFactory(GoogleMap map)
        {
            this.map = map;
        }

        public PolygonBuilder Add()
        {
            var polygon = new Polygon(map);

            map.Polygons.Add(polygon);

            return new PolygonBuilder(polygon);
        }
    }
}
