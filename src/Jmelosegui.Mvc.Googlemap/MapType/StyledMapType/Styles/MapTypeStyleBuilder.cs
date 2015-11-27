// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public class MapTypeStyleBuilder
    {
        public MapTypeStyleBuilder(MapTypeStyle style)
        {
            this.Style = style;
        }

        protected MapTypeStyleBuilder(MapTypeStyleBuilder builder)
            : this(PassThroughNonNull(builder).Style)
        {
        }

        protected MapTypeStyle Style { get; private set; }

        public MapTypeStyleBuilder FeatureType(FeatureType value)
        {
            this.Style.FeatureType = value;
            return this;
        }

        public MapTypeStyleBuilder ElementType(ElementType value)
        {
            this.Style.ElementType = value;
            return this;
        }

        public MapTypeStyleBuilder Color(Color value)
        {
            this.Style.Stylers.Add(new { color = value.ToHtml() });
            return this;
        }

        public MapTypeStyleBuilder Gamma(float value)
        {
            this.Style.Stylers.Add(new { gamma = value });
            return this;
        }

        public MapTypeStyleBuilder HueColor(Color value)
        {
            this.Style.Stylers.Add(new { hue = value.ToHtml() });
            return this;
        }

        public MapTypeStyleBuilder InvertLightness(bool value)
        {
            this.Style.Stylers.Add(new { invert_lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Visibility(MapTypeStylerVisibility value)
        {
            this.Style.Stylers.Add(new { visibility = value.ToClientSideString() });
            return this;
        }

        public MapTypeStyleBuilder Lightness(int value)
        {
            this.Style.Stylers.Add(new { lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Saturation(int value)
        {
            this.Style.Stylers.Add(new { saturation = value });
            return this;
        }

        public MapTypeStyleBuilder Weight(float value)
        {
            this.Style.Stylers.Add(new { weight = value });
            return this;
        }

        private static MapTypeStyleBuilder PassThroughNonNull(MapTypeStyleBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}