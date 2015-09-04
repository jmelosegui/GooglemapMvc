namespace Jmelosegui.Mvc.GoogleMap
{
    public class Overlay : MapObject
    {
        public Overlay(Map map) : base(map)
        {
        }

        public virtual double? Longitude { get; set; }
        public virtual double? Latitude { get; set; }
    }
}