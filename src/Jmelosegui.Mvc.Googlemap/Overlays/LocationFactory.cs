
namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class LocationFactory<TShape> where TShape : Polygon
    {
        private readonly TShape shape;

        public LocationFactory(TShape shape)
        {
            this.shape = shape;
        }

        public ShapeBuilder<TShape> Add(double latitude, double longitude)
        {
            var loc = new Location(latitude, longitude);

            shape.AddPoint(loc);

            return new ShapeBuilder<TShape>(shape);
        }
    }
}
