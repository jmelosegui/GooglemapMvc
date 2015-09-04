namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class PolygonFactory : MapObject, IHideObjectMembers
    {
        public PolygonFactory(GoogleMap map) : base(map)
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
