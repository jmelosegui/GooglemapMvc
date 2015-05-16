namespace Jmelosegui.Mvc.Googlemap
{
    public class LocationFactory<TILocationContainer> where TILocationContainer : ILocationContainer
    {
        private readonly TILocationContainer locationContainer;

        public LocationFactory(TILocationContainer locationContainer)
        {
            this.locationContainer = locationContainer;
        }

        public void Add(double latitude, double longitude)
        {
            var loc = new Location(latitude, longitude);
            locationContainer.AddPoint(loc);
        }
    }
}
