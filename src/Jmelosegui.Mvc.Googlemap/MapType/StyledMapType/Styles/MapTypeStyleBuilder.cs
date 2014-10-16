using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeStyleBuilder
    {
        private readonly MapTypeStyle style;
        public MapTypeStyleBuilder(MapTypeStyle style)
        {
            this.style = style;
        }

        public MapTypeStyleBuilder FeatureType(FeatureType featureType)
        {
            style.FeatureType = featureType;
            return this;
        }

        public MapTypeStyleBuilder ElementType(ElementType elementType)
        {
            style.ElementType = elementType;
            return this;
        }

        public MapTypeStyleBuilder Color(Color color)
        {
            style.Stylers.Add(new { color = color.ToHtml() } );
            return this;
        }

        public MapTypeStyleBuilder Gamma(float gamma)
        {
            style.Stylers.Add(new { gamma });
            return this;
        }

        public MapTypeStyleBuilder HueColor(Color hueColor)
        {
            style.Stylers.Add(new { hue = hueColor.ToHtml() });
            return this;
        }

        public MapTypeStyleBuilder InvertLightness(bool value)
        {
            style.Stylers.Add(new { invert_lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Visibility(MapTypeStylerVisibility value)
        {
            style.Stylers.Add(new { visibility = value.ToClientSideString() });
            return this;
        }

        public MapTypeStyleBuilder Lightness(int value)
        {
            style.Stylers.Add(new { lightness = value });
            return this;
        }

        public MapTypeStyleBuilder Saturation(int value)
        {
            style.Stylers.Add(new { saturation = value });
            return this;
        }

        public MapTypeStyleBuilder Weight(float value)
        {
            style.Stylers.Add(new { weight = value });
            return this;
        }
    }
}