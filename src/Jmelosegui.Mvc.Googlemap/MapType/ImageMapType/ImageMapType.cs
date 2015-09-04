using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class ImageMapType : MapTypeBase
    {
        public ImageMapType()
        {
            TileSize = new Size(256, 256);
            RepeatHorizontally = true;
            RepeatVertically = false;
        }

        public Size TileSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string TileUrlPattern { get; set; }

        public bool RepeatHorizontally { get; set; }

        public bool RepeatVertically { get; set; }

        public override ISerializer CreateSerializer()
        {
            return new ImageMapTypeSerializer(this);
        }
    }
}
