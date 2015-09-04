using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringStyles
    {
        public Uri Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int FontSize { get; set; }
        public Color FontColor { get; set; }

        public ISerializer CreateSerializer()
        {
            return new MarkerClusteringStylesSerializer(this);
        }
    }
}