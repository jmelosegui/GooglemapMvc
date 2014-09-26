namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class Circle : Shape
    {
        public Circle(GoogleMap map) : base(map)
        {

        }

        public Location Center { get; set; }

        public int Radius { get; set; }

        public override IOverlaySerializer CreateSerializer()
        {
            return new CircleSerializer(this);
        }
    }
}
