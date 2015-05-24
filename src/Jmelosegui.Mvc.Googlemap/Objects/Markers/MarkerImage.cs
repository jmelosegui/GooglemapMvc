using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerImage
    {
        private string path;

        public MarkerImage(string path, Size size, Point point, Point anchor)
        {
            Path = System.Web.VirtualPathUtility.ToAbsolute(path);
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
                path = System.Web.VirtualPathUtility.ToAbsolute(value);
            }
        }

        public Point Point { get; set; }

        public Size Size { get; set; }
    }
}
