using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class InfoWindowBuilder
    {
        protected InfoWindowBuilder(InfoWindowBuilder builder) : this(builder.Window)
        {
        }

        public InfoWindowBuilder(InfoWindow window)
        {
            this.Window = window;
        }

        protected InfoWindow Window { get; private set; }

        public InfoWindowBuilder Content(Action content)
        {
            Window.Template.Content = content;
            return this;
        }

        public InfoWindowBuilder Content(Func<object, object> content)
        {
            Window.Template.InlineTemplate = content;
            return this;
        }

        public InfoWindowBuilder DisableAutoPan(bool disable)
        {
            Window.DisableAutoPan = disable;
            return this;
        }

       public InfoWindowBuilder OpenOnRightClick(bool value)
        {
            Window.OpenOnRightClick = value;
            return this;
        }

        public InfoWindowBuilder Latitude(double value)
        {
            Window.Latitude = value;
            return this;
        }

        public InfoWindowBuilder Longitude(double value)
        {
            Window.Longitude = value;
            return this;
        }

        public InfoWindowBuilder MaxWidth(int value)
        {
            Window.MaxWidth = value;
            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "z")]
        public InfoWindowBuilder zIndex(int value)
        {
            Window.zIndex = value;
            return this;
        }
    }
}
