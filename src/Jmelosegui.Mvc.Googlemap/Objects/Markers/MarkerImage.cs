using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerImage
    {
        private string path;

        public MarkerImage(string path, Size size, Point point, Point anchor)
        {
            Path = path.ToAbsoluteUrl();
            Size = size;
            Point = point;
            Anchor = anchor;
        }

        public Point Anchor { get; set; }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value.ToAbsoluteUrl();
            }
        }

        public Point Point { get; set; }

        public Size Size { get; set; }
    }
}
