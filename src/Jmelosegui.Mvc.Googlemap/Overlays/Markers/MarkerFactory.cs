namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerFactory : IHideObjectMembers
    {
        private readonly GoogleMap map;

        public MarkerFactory(GoogleMap map)
        {
            this.map = map;
        }

        public MarkerBuilder Add()
        {
            var marker = new Marker(map);

            map.Markers.Add(marker);

            return new MarkerBuilder(marker);
        }
    }
}
