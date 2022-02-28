// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class InfoWindowBuilder
    {
        public InfoWindowBuilder(InfoWindow window)
        {
            this.Window = window;
        }

        protected InfoWindowBuilder(InfoWindowBuilder builder)
            : this(PassThroughNonNull(builder).Window)
        {
        }

        protected InfoWindow Window { get; private set; }

        public InfoWindowBuilder Content(Action action)
        {
            this.Window.Template.Content = action;
            return this;
        }

        public InfoWindowBuilder Content(Func<object, object> function)
        {
            this.Window.Template.InlineTemplate = function;
            return this;
        }

        public InfoWindowBuilder DisableAutoPan(bool disable)
        {
            this.Window.DisableAutoPan = disable;
            return this;
        }

        public InfoWindowBuilder OpenOnRightClick(bool value)
        {
            this.Window.OpenOnRightClick = value;
            return this;
        }

        public InfoWindowBuilder Latitude(double value)
        {
            this.Window.Latitude = value;
            return this;
        }

        public InfoWindowBuilder Longitude(double value)
        {
            this.Window.Longitude = value;
            return this;
        }

        public InfoWindowBuilder MaxWidth(int value)
        {
            this.Window.MaxWidth = value;
            return this;
        }

        public InfoWindowBuilder ZIndex(int value)
        {
            this.Window.ZIndex = value;
            return this;
        }

        private static InfoWindowBuilder PassThroughNonNull(InfoWindowBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
