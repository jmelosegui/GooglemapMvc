// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class KmlLayerBuilder : LayerBuilder<KmlLayer>
    {
        internal KmlLayerBuilder(KmlLayer kmlLayer)
            : base(kmlLayer)
        {
        }

        public KmlLayerBuilder Clickable(bool value)
        {
            this.Layer.Clickable = value;

            return this;
        }

        public KmlLayerBuilder PreserveViewport(bool value)
        {
            this.Layer.PreserveViewport = value;

            return this;
        }

        public KmlLayerBuilder ScreenOverlays(bool value)
        {
            this.Layer.ScreenOverlays = value;
            return this;
        }

        public KmlLayerBuilder SuppressInfoWindows(bool value)
        {
            this.Layer.SuppressInfoWindows = value;
            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Could be a virtual Url")]
        public KmlLayerBuilder Url(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), "Url cannot be null");
            }

            this.Layer.Url = new Uri(value.ToAbsoluteUrl());

            return this;
        }

        public KmlLayerBuilder ZIndex(int value)
        {
            this.Layer.ZIndex = value;
            return this;
        }
    }
}