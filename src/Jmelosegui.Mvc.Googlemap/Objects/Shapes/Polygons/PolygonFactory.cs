namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class PolygonFactory : IHideObjectMembers
    {
        public PolygonFactory(GoogleMap map)
        {
            this.Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public PolygonBuilder Add()
        {
            var polygon = new Polygon(Map);

            Map.Polygons.Add(polygon);

            return new PolygonBuilder(polygon);
        }
    }
}
