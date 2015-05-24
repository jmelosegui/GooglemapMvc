namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class Overlay : MapObject
    {
        public Overlay(GoogleMap map) : base(map)
        {
        }

        public virtual double? Longitude { get; set; }
        public virtual double? Latitude { get; set; }
    }
}