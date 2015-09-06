using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class InfoWindowBuilder
    {
        protected InfoWindowBuilder(InfoWindowBuilder builder) : this(PassThroughNonNull(builder).Window)
        {
        }

        public InfoWindowBuilder(InfoWindow window)
        {
            this.Window = window;
        }

        protected InfoWindow Window { get; private set; }

        public InfoWindowBuilder Content(Action action)
        {
            Window.Template.Content = action;
            return this;
        }

        public InfoWindowBuilder Content(Func<object, object> function)
        {
            Window.Template.InlineTemplate = function;
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

        public InfoWindowBuilder ZIndex(int value)
        {
            Window.ZIndex = value;
            return this;
        }

        private static InfoWindowBuilder PassThroughNonNull(InfoWindowBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}
