using System;
using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeStyleBuilder
    {
        public MapTypeStyleBuilder(MapTypeStyleBuilder builder) : this(PassThroughNonNull(builder).Style)
        {
        }
        public MapTypeStyleBuilder(MapTypeStyle style)
        {
            Style = style;
        }

        protected MapTypeStyle Style { get; private set; }

        public MapTypeStyleBuilder FeatureType(FeatureType value)
        {
            Style.FeatureType = value;
            return this;
        }

        public MapTypeStyleBuilder ElementType(ElementType value)
        {
            Style.ElementType = value;
            return this;
        }

        public MapTypeStyleBuilder Color(Color value)
        {
            Style.Stylers.Add(new { color = value.ToHtml() } );
            return this;
        }

        public MapTypeStyleBuilder Gamma(float value)
        {
            Style.Stylers.Add(new { gamma = value });
            return this;
        }

        public MapTypeStyleBuilder HueColor(Color value)
        {
            Style.Stylers.Add(new { hue = value.ToHtml() });
            return this;
        }

        public MapTypeStyleBuilder InvertLightness(bool value)
        {
            Style.Stylers.Add(new { invert_lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Visibility(MapTypeStylerVisibility value)
        {
            Style.Stylers.Add(new { visibility = value.ToClientSideString() });
            return this;
        }

        public MapTypeStyleBuilder Lightness(int value)
        {
            Style.Stylers.Add(new { lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Saturation(int value)
        {
            Style.Stylers.Add(new { saturation = value });
            return this;
        }

        public MapTypeStyleBuilder Weight(float value)
        {
            Style.Stylers.Add(new { weight = value });
            return this;
        }


        private static MapTypeStyleBuilder PassThroughNonNull(MapTypeStyleBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}