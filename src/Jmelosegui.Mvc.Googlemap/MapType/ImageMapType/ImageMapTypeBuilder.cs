using System;
using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ImageMapTypeBuilder : MapTypeBuilder<ImageMapType>
    {
        readonly ImageMapType mapType;

        public ImageMapTypeBuilder(ImageMapType mapType) : base(mapType)
        {
            this.mapType = mapType;
        }

        public ImageMapTypeBuilder TileSize(Size value)
        {
            mapType.TileSize = value;
            return this;
        }

        public ImageMapTypeBuilder RepeatHorizontally(bool value)
        {
            mapType.RepeatHorizontally = value;
            return this;
        }

        public ImageMapTypeBuilder RepeatVertically(bool value)
        {
            mapType.RepeatVertically = value;
            return this;
        }

        public ImageMapTypeBuilder TileUrlPattern(string value)
        {
            mapType.TileUrlPattern = value.ToAbsoluteUrl();
            return this;
        }
    }
}
