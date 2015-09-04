namespace Jmelosegui.Mvc.GoogleMap
{
    public class PolygonFactory : MapObject, IHideObjectMembers
    {
        public PolygonFactory(Map map) : base(map)
        {
        }

        public PolygonBuilder Add()
        {
            var polygon = new Polygon(Map);

            Map.Polygons.Add(polygon);

            return new PolygonBuilder(polygon);
        }
    }
}
