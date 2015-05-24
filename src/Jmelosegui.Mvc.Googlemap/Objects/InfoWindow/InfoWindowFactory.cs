namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class InfoWindowFactory : IHideObjectMembers
    {
        private readonly Marker marker;

        public InfoWindowFactory(Marker marker)
        {
            this.marker = marker;
        }

        public InfoWindowBuilder Add()
        {
            var window = new InfoWindow(marker);

            marker.Window = window;

            return new InfoWindowBuilder(window);
        }
    }
}
