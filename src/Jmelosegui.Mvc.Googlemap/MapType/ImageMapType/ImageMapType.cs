using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ImageMapType : MapType
    {
        public ImageMapType()
        {
            Radius = 6378137;
            TileSize = new Size(256, 256);
            RepeatHorizontally = true;
            RepeatVertically = false;
            Opacity = 100;
        }

        public Size TileSize { get; set; }

        public string TileUrlPattern { get; set; }

        public bool RepeatHorizontally { get; set; }

        public bool RepeatVertically { get; set; }

        public override ISerializer CreateSerializer()
        {
            return new ImageMapTypeSerializer(this);
        }
    }
}
