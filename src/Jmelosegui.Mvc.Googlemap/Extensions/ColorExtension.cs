using System.Drawing;

namespace Jmelosegui.Mvc.Googlemap
{
    static class ColorExtension
    {
        public static string ToHtml(this Color c)
        {
            return ("#" + c.R.ToString("X2", null) + c.G.ToString("X2", null) + c.B.ToString("X2", null));

        }
    }
}