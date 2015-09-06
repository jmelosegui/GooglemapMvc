namespace Jmelosegui.Mvc.GoogleMap
{
    public class Circle : Shape
    {
        public Circle(Map map) : base(map)
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
