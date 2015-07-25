using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeStyleBuilder
    {
        public MapTypeStyleBuilder(MapTypeStyleBuilder builder)
            : this(builder.Style)
        {
        }
        public MapTypeStyleBuilder(MapTypeStyle style)
        {
            Style = style;
        }

        protected MapTypeStyle Style { get; private set; }

        public MapTypeStyleBuilder FeatureType(FeatureType featureType)
        {
            Style.FeatureType = featureType;
            return this;
        }

        public MapTypeStyleBuilder ElementType(ElementType elementType)
        {
            Style.ElementType = elementType;
            return this;
        }

        public MapTypeStyleBuilder Color(Color color)
        {
            Style.Stylers.Add(new { color = color.ToHtml() } );
            return this;
        }

        public MapTypeStyleBuilder Gamma(float gamma)
        {
            Style.Stylers.Add(new { gamma });
            return this;
        }

        public MapTypeStyleBuilder HueColor(Color hueColor)
        {
            Style.Stylers.Add(new { hue = hueColor.ToHtml() });
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
    }
}