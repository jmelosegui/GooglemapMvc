namespace Jmelosegui.Mvc.GoogleMap
{
    public class CenterFactory
    {
        public CenterFactory(Map map)
        {
            Map = map;
        }

        protected Map Map { get; private set; }

        public CenterFactory UseCurrentPosition()
        {
            Map.UseCurrentPosition = true;
            return this;
        }

        public CenterFactory Latitude(double value)
        {
            Map.Latitude = value;
            return this;
        }

        public CenterFactory Longitude(double value)
        {
            Map.Longitude = value;
            return this;
        }

        public void Address(string value)
        {
            Map.Address = value;
        }
    }
}
