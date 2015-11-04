namespace Jmelosegui.Mvc.GoogleMap
{
    public class PolylineFactory : MapObject, IHideObjectMembers
    {
        public PolylineFactory(Map map) : base(map)
        {
        }

        public PolylineBuilder Add()
        {
            var polyline = new Polyline(Map);

            Map.Polylines.Add(polyline);

            return new PolylineBuilder(polyline);
        }
    }
}
