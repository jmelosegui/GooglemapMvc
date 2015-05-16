namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class LocationOverlay : Overlay
    {
        public LocationOverlay(GoogleMap map) : base(map)
        {
        }

        public virtual double? Longitude { get; set; }
        public virtual double? Latitude { get; set; }
    }
}