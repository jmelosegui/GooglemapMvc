using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class InfoWindowBuilder
    {
        private readonly InfoWindow window;

        public InfoWindowBuilder(InfoWindow window)
        {
            this.window = window;
        }

        public InfoWindowBuilder Content(Action content)
        {
            window.Template.Content = content;
            return this;
        }

        public InfoWindowBuilder Content(Func<object, object> content)
        {
            window.Template.InlineTemplate = content;
            return this;
        }

        public InfoWindowBuilder DisableAutoPan(bool disable)
        {
            window.DisableAutoPan = disable;
            return this;
        }

       public InfoWindowBuilder OpenOnRightClick(bool value)
        {
            window.OpenOnRightClick = value;
            return this;
        }

        public InfoWindowBuilder Latitude(double value)
        {
            window.Latitude = value;
            return this;
        }

        public InfoWindowBuilder Longitude(double value)
        {
            window.Longitude = value;
            return this;
        }

        public InfoWindowBuilder MaxWidth(int value)
        {
            window.MaxWidth = value;
            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "z")]
        public InfoWindowBuilder zIndex(int value)
        {
            window.zIndex = value;
            return this;
        }
    }
}
