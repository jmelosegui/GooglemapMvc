namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class Circle : Shape
    {
        public Circle(GoogleMap map) : base(map)
        {

        }

        public Location Center { get; set; }

        public int Radius { get; set; }

        public override ISerializer CreateSerializer()
        {
            return new CircleSerializer(this);
        }
    }
}
