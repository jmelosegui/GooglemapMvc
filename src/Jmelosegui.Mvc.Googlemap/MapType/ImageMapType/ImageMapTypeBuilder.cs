using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ImageMapTypeBuilder : MapTypeBuilder<ImageMapType>
    {
        public ImageMapTypeBuilder(ImageMapType mapType) : base(mapType)
        {
        }

        public ImageMapTypeBuilder TileSize(Size value)
        {
            base.MapType.TileSize = value;
            return this;
        }

        public ImageMapTypeBuilder RepeatHorizontally(bool value)
        {
           base.MapType.RepeatHorizontally = value;
            return this;
        }

        public ImageMapTypeBuilder RepeatVertically(bool value)
        {
            base.MapType.RepeatVertically = value;
            return this;
        }

        public ImageMapTypeBuilder TileUrlPattern(string value)
        {
            base.MapType.TileUrlPattern = value.ToAbsoluteUrl();
            return this;
        }
    }
}
